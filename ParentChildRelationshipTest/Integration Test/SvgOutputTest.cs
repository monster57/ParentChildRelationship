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
            _expected = "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">" +
                        "<text x=\"500\" y=\"10\" font-family=\"Verdana\" font-size=\"10\">1</text>" +
                        "<text x=\"480\" y=\"30\" font-family=\"Verdana\" font-size=\"10\">1</text>" +
                        "<text x=\"520\" y=\"30\" font-family=\"Verdana\" font-size=\"10\">1</text>" +
                        "<line x1=\"510\" y1=\"10\" x2=\"490\" y2=\"20\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>" +
                        "<line x1=\"510\" y1=\"10\" x2=\"530\" y2=\"20\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>";
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