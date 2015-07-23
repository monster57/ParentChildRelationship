using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            return mappedParentIdWithDimension.ToDictionary(
                pair => pair.Key,
                pair => DatabaseUtils.ExecuteQuery(
                    QueryCreator.GetChildIdQuery(pair.Value))
                    .GetDataRows()
                    .Select(Fact.GetFactFromRow));
        }

        public IDictionary<string, IEnumerable<Fact>> GetParentToChildrenMap()
        {
            return GetChildrenRelatedToParent(GetParentDimensionMap());
        }
    }
}