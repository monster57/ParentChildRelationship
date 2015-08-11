using System.Collections.Generic;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Integration_Test
{
    [TestFixture]
    public class SvgOutputTest
    {
        [SetUp]
        public void Init()
        {
            var anchor1 = new Anchor {Data = "1"};
            var anchor2 = new Anchor {Data = "2"};
            var anchor3 = new Anchor {Data = "3"};
            anchor1.Children = new List<Anchor> {anchor2, anchor3};
            _parentList = new List<Anchor> {anchor1};
            _expected = "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">\n" +
                        "<text x=\"0\" y=\"10\" font-family=\"Verdana\" font-size=\"10\">1</text>\n" +
                        "<text x=\"40\" y=\"10\" font-family=\"Verdana\" font-size=\"10\">2</text>\n" +
                        "<text x=\"40\" y=\"30\" font-family=\"Verdana\" font-size=\"10\">3</text>\n" +
                        "<line x1=\"20\" y1=\"5\" x2=\"40\" y2=\"5\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                        "<line x1=\"20\" y1=\"5\" x2=\"40\" y2=\"25\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n"+
                        "</svg>";
        }

        private List<Anchor> _parentList;
        private string _expected;

        [Test]
        public void ShouldGiveSvgCodeForTree()
        {
            Assert.AreEqual(_expected, new SvgOutput(_parentList).GetSvg());
        }
    }
}