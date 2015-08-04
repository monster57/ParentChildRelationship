using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ParentChildRelationship
{
    public class ParentChildUtil
    {
        private static IDictionary<string, FactDimensions> GetParentDimensionMap()
        {
            return
                ConnectionPool.Execute(QueryCreator.GetParentIdQuery())
                    .GetDataRows()
                    .Where(IsRowValid)
                    .ToDictionary(row => row.GetValue(ConfigSettings.Id), FactDimensions.GetFactDimensionsFromRow);
        }

        private static bool IsRowValid(DataRow row)
        {
            return !string.IsNullOrEmpty(row.GetValue(ConfigSettings.Id));
        }

        private static IDictionary<string, IEnumerable<Fact>> GetChildrenRelatedToParent(
            IDictionary<string, FactDimensions> mappedParentIdWithDimension)
        {
            var ret = new ConcurrentDictionary<string, IEnumerable<Fact>>();
            Parallel.ForEach(mappedParentIdWithDimension,
                new ParallelOptions {MaxDegreeOfParallelism = ConfigSettings.DegreeOfParallelism}, pair =>
                {
                    var c = QueryCreator.GetChildIdQuery(pair.Value);                   
                    ret[pair.Key] =
                        ConnectionPool.Execute(QueryCreator.GetChildIdQuery(pair.Value))
                            .GetDataRows()
                            .Select(Fact.GetFactFromRow);
                });
            return ret;
        }

        public IDictionary<string, IEnumerable<Fact>> GetParentToChildrenMap()
        {
            ConnectionPool.Initialize(ConfigSettings.ConnectionCount);
            return GetChildrenRelatedToParent(GetParentDimensionMap());
        }
    }
}