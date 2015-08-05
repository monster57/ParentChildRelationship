using System.Collections.Generic;
using System.Linq;

namespace ParentChildRelationship
{
    public class RelationMapper
    {
        private static IDictionary<string, IEnumerable<Fact>> _mappingSet;

        public RelationMapper(IDictionary<string, IEnumerable<Fact>> map)
        {
            _mappingSet = map;
        }

        public List<List<string>> GiveRelationList()
        {
            var result = new List<List<string>>();
            var usedKey = new List<string>();
            foreach (var keyValuePair in _mappingSet.Where(keyValuePair => !usedKey.Contains(keyValuePair.Key)))
            {
                CreateRelationList(usedKey, new List<string>(), result, keyValuePair.Key);
            }
            return result;
        }

        private static void CreateRelationList(ICollection<string> usedKeys,
            ICollection<string> singleRelationshipHolder, ICollection<List<string>> result, string key)
        {
            IEnumerable<Fact> children;
            singleRelationshipHolder.Add(key);
            usedKeys.Add(key);
            if (!_mappingSet.TryGetValue(key, out children))
            {
                result.Add(new List<string>(singleRelationshipHolder));
                return;
            }
            foreach (var child in children)
            {
                if (singleRelationshipHolder.Contains(child.FactId))
                {
                    result.Add(new List<string>(singleRelationshipHolder));
                    return;
                }
                CreateRelationList(usedKeys, singleRelationshipHolder, result, child.FactId);
                singleRelationshipHolder.Remove(child.FactId);
            }
        }
    }
}