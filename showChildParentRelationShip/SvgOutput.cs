using System.Collections.Generic;
using System.Linq;

namespace ParentChildRelationship
{
    public class SvgOutput
    {
        private List<Anchor> _anchors;

        public SvgOutput(List<Anchor> anchors)
        {
            _anchors = anchors;
        }

        public string GetSvg()
        {
            var head = "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">";
            var tail = "</svg>";
            var anchor = _anchors.First();
            return "";
        }
    }
}


//<svg xmlns="http://www.w3.org/2000/svg" version="1.1">
//  <rect x="25" y="25" width="200" height="200" fill="lime" stroke-width="4" stroke="pink" />
//  <circle cx="125" cy="125" r="75" fill="orange" />
//  <polyline points="50,150 50,200 200,200 200,100" stroke="red" stroke-width="4" fill="none" />
//  <line x1="50" y1="50" x2="200" y2="200" stroke="blue" stroke-width="4" />
//</svg>