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
            var list1 = new List<Fact> {new Fact {FactId = "2"}, new Fact {FactId = "3"}};
            var list2 = new List<Fact> {new Fact {FactId = "1"}, new Fact {FactId = "5"}};
            dictionary.Add("1", list1);
            dictionary.Add("4", list2);
            _stringListDictionary = dictionary;
            _expected = new List<Anchor>();
            var nodeList1 = new List<Anchor> {new Anchor {Data = "2"}, new Anchor {Data = "3"}};
            var nodeList2 = new List<Anchor> {new Anchor {Data = "1"}, new Anchor {Data = "5"}};
            var node1 = new Anchor {Data = "1", Children = nodeList1};
            var node2 = new Anchor {Data = "4", Children = nodeList2};
            _expected.Add(node1);
        }

        private static IDictionary<string, IEnumerable<Fact>> _stringListDictionary;
        private static List<Anchor> _expected;

        [Test]
        public void AddNodeListToEachListElement()
        {
            var actual = ParentNodeList.GetParentNodeList(ParentNodeList.CreateNodeListFrom(_stringListDictionary),
                _stringListDictionary);
            for (var i = 0; i < _expected.Count; i++)
            {
                Assert.AreEqual(_expected[i].Data, actual[i].Data);
                for (var j = 0; j < _expected[i].Children.Count; j++)
                {
                    Assert.AreEqual(_expected[i].Children[j].Data, actual[i].Children[j].Data);
                }
            }
        }

        [Test]
        public void ShouldGetAListOfNode()
        {
            var expected = new List<Anchor> {new Anchor {Data = "1"}};
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Data,
                    ParentNodeList.CreateNodeListFrom(_stringListDictionary)[i].Data);
            }
        }

        [Test]
        public void ShouldNotCreateTwoDifferentNodeForSameString()
        {
            var actual = ParentNodeList.GetParentNodeList(ParentNodeList.CreateNodeListFrom(_stringListDictionary),
                _stringListDictionary);
            var node = actual[0];
            var nodeList = actual[1].Children;
            Assert.True(nodeList.Contains(node));
        }
    }
}