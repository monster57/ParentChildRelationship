using System.Collections.Generic;
using System.Linq;

namespace ParentChildRelationship
{
    public static class ParentList
    {
        public static HashSet<Anchor> GetAnchorList(IDictionary<string, IEnumerable<Fact>> dictionary)
        {
            return CreateAnchorList(dictionary, CreateFactSet(dictionary)
                .Select(fact => new Anchor {Data = fact}).ToList());
        }

        private static HashSet<Anchor> CreateAnchorList(IDictionary<string, IEnumerable<Fact>> dictionary,
            List<Anchor> anchorList)
        {
            var parentSet = new HashSet<Anchor>();
            foreach (var keyValPair in dictionary)
            {
                var children = (from fact in keyValPair.Value from anchor in anchorList
                        where anchor.Data == fact.FactId select anchor).ToList();
                AddAnchorToSet(anchorList, keyValPair, children, parentSet);
            }
            return parentSet;
        }

        private static void AddAnchorToSet(IEnumerable<Anchor> anchorList, KeyValuePair<string, IEnumerable<Fact>> pair, List<Anchor> children, ISet<Anchor> parentSet)
        {
            foreach (var anchor in anchorList.Where(anchor => anchor.Data == pair.Key))
            {
                anchor.Children = children;
                parentSet.Add(anchor);
            }
        }

        private static HashSet<string> CreateFactSet(IDictionary<string, IEnumerable<Fact>> dictionary)
        {
            var factList = new HashSet<string>();
            foreach (var keyValuePair in dictionary)
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