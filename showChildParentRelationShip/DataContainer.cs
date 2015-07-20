using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ParentChildRelationship
{
    public class ParentChildUtil
    {
        private static IDictionary<string, FactDimensions> GetParentDimensionMap()
        {
            var query = QueryCreator.GetParentIdQuery();
            return DatabaseUtils.ExecuteQuery(QueryCreator.GetParentIdQuery())
                .GetDataRows()
                .Where(IsRowValid)
                .ToDictionary(row => row.GetValue(Constants.FactDataId), FactDimensions.GetFactDimensionsFromRow);
        }

        private static bool IsRowValid(DataRow row)
        {
            return !string.IsNullOrEmpty(row.GetValue(Constants.FactDataId));
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