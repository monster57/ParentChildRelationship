using System.Collections.Generic;
using System.Text;

namespace ParentChildRelationShip
{
    class RelationshipCreator
    {
        public string GetParentChildRelationship(Dictionary<string, List<Fact>> mappedParentIdWithChildId)
        {
            var stringBuilder = new StringBuilder();
            foreach (var parentChildIdPair in mappedParentIdWithChildId)
            {
                foreach (var fact in parentChildIdPair.Value)
                {
                    stringBuilder.Append(parentChildIdPair.Key);
                    stringBuilder.Append(" ==> ");
                    stringBuilder.Append(fact.FactId);
                    stringBuilder.Append("\n");
                }
            }
            return stringBuilder.ToString();
        }
    }
}