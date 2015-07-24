using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParentChildRelationship
{
    public class ParentChildUtil
    {
        private static IDictionary<string, FactDimensions> GetParentDimensionMap()
        {
            return DatabaseUtils.ExecuteQuery(QueryCreator.GetParentIdQuery())
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
            Parallel.ForEach(mappedParentIdWithDimension, new ParallelOptions {MaxDegreeOfParallelism = 3}, (pair) =>
            {
                ret[pair.Key] = DatabaseUtils.ExecuteQuery(
                    QueryCreator.GetChildIdQuery(pair.Value))
                    .GetDataRows()
                    .Select(Fact.GetFactFromRow);
            });
            return ret;
        }

        public IDictionary<string, IEnumerable<Fact>> GetParentToChildrenMap()
        {
            return GetChildrenRelatedToParent(GetParentDimensionMap());
        }
    }
}