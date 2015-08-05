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
    }
}
