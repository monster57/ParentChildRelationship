using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentChildRelationship
{
    public static class ParentNodeList
    {
        

        public static List<Node> CreateNodeListFrom(Dictionary<string, List<string>> dictionary)
        {
            return dictionary.Select(keyValuePair => new Node {NodeData = keyValuePair.Key}).ToList();
        }

        public static List<Node> GetParentNodeList(List<Node> list, Dictionary<string, List<string>> stringListDictionary)
        {
            
            foreach (var node in list)
            {
                List<string> children;
                stringListDictionary.TryGetValue(node.NodeData, out children);
                var nodeList =  AddNodesToList(list, children);
                node.NodeList = nodeList;
            }
            return list;
        }

        private static List<Node> AddNodesToList(List<Node> list, IEnumerable<string> children)
        {
            var nodeList = new List<Node>();
            foreach (var child in children)
            {
                AddNode(list, child, nodeList);
            }
            return nodeList;
        }

        private static void AddNode(IEnumerable<Node> list, string child, ICollection<Node> nodeList)
        {
            var marker = 0;
            foreach (var parentNode in list.Where(parentNode => parentNode.NodeData == child))
            {
                marker = 1;
                nodeList.Add(parentNode);
            }
            if (marker == 0)
            {
                nodeList.Add(new Node {NodeData = child});
            }
        }
    }
}
