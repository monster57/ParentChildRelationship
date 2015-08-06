using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentChildRelationship
{
    public class Anchor
    {
        public string Data { get; set; }

        public List<Anchor> Children { get; set; }
    }
}
