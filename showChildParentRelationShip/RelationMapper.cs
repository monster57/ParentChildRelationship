using System.Collections.Generic;

namespace ParentChildRelationship
{
    public class RelationMapper
    {
        private static HashSet<Anchor> _nodeList;

        public RelationMapper(HashSet<Anchor> nodeList)
        {
            _nodeList = nodeList;
        }

        public List<RelationshipTree> GetRelationTreeList()
        {
            var result = new List<RelationshipTree>();
            var usedKey = new List<Anchor>();
            foreach (var node in _nodeList)
            {
                if (!usedKey.Contains(node)) result.Add(new RelationshipTree {Root = node});
                CreateNodeList(usedKey, node);
            }
            return result;
        }

        private static void CreateNodeList(ICollection<Anchor> usedKeys, Anchor anchor)
        {
            usedKeys.Add(anchor);
            if (anchor.Children == null) return;
            foreach (var childNode in anchor.Children)
            {
                if (usedKeys.Contains(childNode)) return;
                CreateNodeList(usedKeys, childNode);
            }
        }
    }
}