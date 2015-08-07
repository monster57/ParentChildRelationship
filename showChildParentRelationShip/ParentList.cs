using System.Collections.Generic;
using System.Linq;

namespace ParentChildRelationship
{
    public static class ParentList
    {
        public static List<Anchor> GetParentSet(IDictionary<string, IEnumerable<Fact>> parentChildDictionary)
        {
            var anchorSet = CreateAnchorSet(parentChildDictionary, GetAllFactIds(parentChildDictionary)
                .Select(fact => new Anchor {Data = fact}).ToList());
            return CreateParentList(anchorSet);
        }

        private static List<Anchor> CreateParentList(IEnumerable<Anchor> anchorList)
        {
            var result = new List<Anchor>();
            var usedKey = new List<Anchor>();
            foreach (var anchor in anchorList)
            {
                if (!usedKey.Contains(anchor)) result.Add(anchor);
                CheckForNonParent(usedKey, anchor, result);
                if (anchor.Children == null) result.Remove(anchor);
            }
            return result;
        }

        private static void CheckForNonParent(ICollection<Anchor> usedKeys, Anchor anchor, List<Anchor> result)
        {
            usedKeys.Add(anchor);
            if (anchor.Children == null) return;
            foreach (var childNode in anchor.Children)
            {
                if (usedKeys.Contains(childNode))
                {
                    result.Remove(childNode);
                    return;
                }
                CheckForNonParent(usedKeys, childNode, result);
            }
        }

        private static IEnumerable<Anchor> CreateAnchorSet(IDictionary<string, IEnumerable<Fact>> dictionary,
            List<Anchor> anchorList)
        {
            foreach (var keyValPair in dictionary)
            {
                var children = (from fact in keyValPair.Value
                    from anchor in anchorList
                    where anchor.Data == fact.FactId
                    select anchor).ToList();
                AddAnchorToSet(anchorList, keyValPair, children);
            }
            return anchorList;
        }

        private static void AddAnchorToSet(IEnumerable<Anchor> anchorList, KeyValuePair<string, IEnumerable<Fact>> pair,
            List<Anchor> children)
        {
            foreach (var anchor in anchorList.Where(anchor => anchor.Data == pair.Key))
            {
                anchor.Children = children;
            }
        }

        private static IEnumerable<string> GetAllFactIds(IDictionary<string, IEnumerable<Fact>> parentChildDictionary)
        {
            var factList = new HashSet<string>();
            foreach (var keyValuePair in parentChildDictionary)
            {
                factList.Add(keyValuePair.Key);
                foreach (var fact in keyValuePair.Value)
                {
                    factList.Add(fact.FactId);
                }
            }
            return factList;
        }
    }
}