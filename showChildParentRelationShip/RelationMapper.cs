using System.Collections.Generic;

namespace ParentChildRelationship
{
    public class RelationMapper
    {
        private static List<Node> _nodeList;

        public RelationMapper(List<Node> nodeList)
        {
            _nodeList = nodeList;
        }

        public List<RelationshipTree> GetRelationTreeList()
        {
            var result = new List<RelationshipTree>();
            var usedKey = new List<Node>();
            foreach (var node in _nodeList)
            {
                if (!usedKey.Contains(node)) result.Add(new RelationshipTree {Root = node});
                CreateNodeList(usedKey, node);
            }
            return result;
        }

        private static void CreateNodeList(ICollection<Node> usedKeys, Node node)
        {
            usedKeys.Add(node);
            if (node.NodeList == null) return;
            foreach (var childNode in node.NodeList)
            {
                if (usedKeys.Contains(childNode)) return;
                CreateNodeList(usedKeys, childNode);
            }
        }
    }
}