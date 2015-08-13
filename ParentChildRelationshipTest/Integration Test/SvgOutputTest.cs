using System.Collections.Generic;
using NUnit.Framework;
using ParentChildRelationship;
using ParentChildRelationship.Svg;

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
            _parentListForSingleLevelChild = new List<Anchor> {anchor1};
            _expectedForSingleLevelChild = "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">\n" +
                                           "<text x=\"0\" y=\"10\" font-family=\"Verdana\" font-size=\"10\">1</text>\n" +
                                           "<text x=\"50\" y=\"10\" font-family=\"Verdana\" font-size=\"10\">2</text>\n" +
                                           "<text x=\"50\" y=\"30\" font-family=\"Verdana\" font-size=\"10\">3</text>\n" +
                                           "<line x1=\"20\" y1=\"5\" x2=\"30\" y2=\"5\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                           "<line x1=\"30\" y1=\"5\" x2=\"50\" y2=\"5\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                           "<line x1=\"30\" y1=\"5\" x2=\"30\" y2=\"5\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                           "<line x1=\"30\" y1=\"25\" x2=\"50\" y2=\"25\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                           "<line x1=\"30\" y1=\"5\" x2=\"30\" y2=\"25\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                           "</svg>";
            var anchor4 = new Anchor {Data = "1"};
            var anchor5 = new Anchor {Data = "2"};
            var anchor6 = new Anchor {Data = "3"};
            var anchor7 = new Anchor {Data = "4"};
            var anchor8 = new Anchor {Data = "5"};
            anchor4.Children = new List<Anchor> {anchor5, anchor6};
            anchor8.Children = new List<Anchor> {anchor7, anchor4};
            _parentListForMultiLevelChild = new List<Anchor> {anchor8};
            _expectedForMultiLevelChild = "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">\n" +
                                          "<text x=\"0\" y=\"10\" font-family=\"Verdana\" font-size=\"10\">5</text>\n" +
                                          "<text x=\"50\" y=\"10\" font-family=\"Verdana\" font-size=\"10\">4</text>\n" +
                                          "<text x=\"50\" y=\"30\" font-family=\"Verdana\" font-size=\"10\">1</text>\n" +
                                          "<text x=\"100\" y=\"30\" font-family=\"Verdana\" font-size=\"10\">2</text>\n" +
                                          "<text x=\"100\" y=\"50\" font-family=\"Verdana\" font-size=\"10\">3</text>\n" +
                                          "<line x1=\"20\" y1=\"5\" x2=\"30\" y2=\"5\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "<line x1=\"30\" y1=\"5\" x2=\"50\" y2=\"5\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "<line x1=\"30\" y1=\"5\" x2=\"30\" y2=\"5\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "<line x1=\"30\" y1=\"25\" x2=\"50\" y2=\"25\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "<line x1=\"30\" y1=\"5\" x2=\"30\" y2=\"25\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "<line x1=\"70\" y1=\"25\" x2=\"80\" y2=\"25\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "<line x1=\"80\" y1=\"25\" x2=\"100\" y2=\"25\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "<line x1=\"80\" y1=\"25\" x2=\"80\" y2=\"25\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "<line x1=\"80\" y1=\"45\" x2=\"100\" y2=\"45\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "<line x1=\"80\" y1=\"25\" x2=\"80\" y2=\"45\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n" +
                                          "</svg>";
        }

        private List<Anchor> _parentListForSingleLevelChild;
        private List<Anchor> _parentListForMultiLevelChild;
        private string _expectedForSingleLevelChild;
        private string _expectedForMultiLevelChild;

        [Test]
        public void ShouldGiveSvgCodeForMultiLevelTree()
        {
            Assert.AreEqual(_expectedForMultiLevelChild, new SvgOutput(_parentListForMultiLevelChild).GetSvg());
        }

        [Test]
        public void ShouldGiveSvgCodeForSingleLevelTree()
        {
            Assert.AreEqual(_expectedForSingleLevelChild, new SvgOutput(_parentListForSingleLevelChild).GetSvg());
        }
    }
}