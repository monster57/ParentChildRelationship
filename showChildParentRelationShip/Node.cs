using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentChildRelationship
{
    public class Node
    {
        public string NodeData { get; set; }

        public List<Node> NodeList { get; set; }
    }
}
