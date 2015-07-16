using System.Collections.Generic;

namespace showChildParentRelationShip
{
    class RelationshipCreator
    {
        
        public Dictionary<string , List<Fact>> GetRelationship(string parentId , List<Fact> childIdSet )
        {
            Dictionary<string, List<Fact>> parentChildRelation = new Dictionary<string, List<Fact>>();
            
            parentChildRelation.Add(parentId , childIdSet);
            

            return parentChildRelation;
        }


    }
}