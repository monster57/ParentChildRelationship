using System.Collections.Generic;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    internal class ParentNodeListTest
    {
        [SetUp]
        public void Init()
        {
            var dictionary = new Dictionary<string, IEnumerable<Fact>>();
            var list1 = new List<Fact> { new Fact { FactId = "2" }, new Fact { FactId = "3" } };
            var list2 = new List<Fact> { new Fact { FactId = "1" }, new Fact { FactId = "5" } };
            dictionary.Add("1", list1 );
            dictionary.Add("4", list2);
            _stringListDictionary = dictionary;
            _expected = new List<Node>();
            var nodeList1 = new List<Node> {new Node {NodeData = "2"}, new Node {NodeData = "3"}};
            var nodeList2 = new List<Node> {new Node {NodeData = "1"}, new Node {NodeData = "5"}};
            var node1 = new Node {NodeData = "1", NodeList = nodeList1};
            var node2 = new Node {NodeData = "4", NodeList = nodeList2};
            _expected.Add(node1);
        }

        private static IDictionary<string, IEnumerable<Fact>> _stringListDictionary;
        private static List<Node> _expected;

        [Test]
        public void AddNodeListToEachListElement()
        {
            var actual = ParentNodeList.GetParentNodeList(ParentNodeList.CreateNodeListFrom(_stringListDictionary),
                _stringListDictionary);
            for (var i = 0; i < _expected.Count; i++)
            {
                Assert.AreEqual(_expected[i].NodeData, actual[i].NodeData);
                for (var j = 0; j < _expected[i].NodeList.Count; j++)
                {
                    Assert.AreEqual(_expected[i].NodeList[j].NodeData, actual[i].NodeList[j].NodeData);
                }
            }
        }

        [Test]
        public void ShouldGetAListOfNode()
        {
            var expected = new List<Node> {new Node {NodeData = "1"}};
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].NodeData,
                    ParentNodeList.CreateNodeListFrom(_stringListDictionary)[i].NodeData);
            }
        }

        [Test]
        public void ShouldNotCreateTwoDifferentNodeForSameString()
        {
            var actual = ParentNodeList.GetParentNodeList(ParentNodeList.CreateNodeListFrom(_stringListDictionary),
                _stringListDictionary);
            var node = actual[0];
            var nodeList = actual[1].NodeList;
            Assert.True(nodeList.Contains(node));
        }
    }
}