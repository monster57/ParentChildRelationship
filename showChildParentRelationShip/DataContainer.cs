using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ParentChildRelationship
{
    public class ParentChildUtil
    {
        private static IDictionary<string, FactDimensions> GetParentDimensionMap()
        {
            return DatabaseUtils.ExecuteQuery(QueryCreator.GetParentIdQuery(), ConnectionPool.GiveMeConnection())
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
                    var sqlConnectionWrapper = ConnectionPool.GiveMeConnection();
                    ret[pair.Key] = DatabaseUtils.ExecuteQuery(
                        QueryCreator.GetChildIdQuery(pair.Value), sqlConnectionWrapper)
                        .GetDataRows()
                        .Select(Fact.GetFactFromRow);

                    //Console.WriteLine("*************************** {0}", sqlConnectionWrapper.Id);
                });
            return ret;
        }

        public IDictionary<string, IEnumerable<Fact>> GetParentToChildrenMap()
        {
            ConnectionPool.Initialize(ConfigSettings.DegreeOfParallelism);
            return GetChildrenRelatedToParent(GetParentDimensionMap());
        }
    }
}