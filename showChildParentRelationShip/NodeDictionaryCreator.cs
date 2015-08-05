using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentChildRelationship
{
    public static class NodeDictionaryCreator
    {
        public static Dictionary<Node , List<string>> GetNodeListDictionary(Dictionary<string, List<string>> stringListDictionary)
        {
            return stringListDictionary.ToDictionary(keyValuePair => new Node {NodeData = keyValuePair.Key}, keyValuePair => keyValuePair.Value);
        }

        public static List<Node> GetNodeDictionary(Dictionary<Node, List<string>> nodeListDictionary)
        {
            var nodeDictionary = new List<Node>();
            foreach (var keyValuePair in nodeListDictionary)
            {
                var nodeList = new List<Node>();
                AddDataInNodeList(nodeListDictionary, keyValuePair, nodeList);
                keyValuePair.Key.NodeList = nodeList;
                nodeDictionary.Add(keyValuePair.Key);
            }
            return nodeDictionary;
        }

        private static void AddDataInNodeList(Dictionary<Node, List<string>> nodeListDictionary, KeyValuePair<Node, List<string>> keyValuePair, List<Node> nodeList)
        {
            foreach (var str in keyValuePair.Value)
            {
                var marker = 0;
                foreach (var keyValPair in nodeListDictionary.Where(keyValPair => keyValPair.Key.NodeData == str))
                {
                    marker = 1;
                    nodeList.Add(keyValPair.Key);
                }
                if (marker == 0)
                    nodeList.Add(new Node {NodeData = str});
            }
        }
    }
}
