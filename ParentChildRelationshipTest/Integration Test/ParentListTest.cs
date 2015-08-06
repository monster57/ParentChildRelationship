using System.Collections.Generic;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Integration_Test
{
    [TestFixture]
    internal class ParentListTest
    {
        [SetUp]
        public void Init()
        {
            var dictionary = new Dictionary<string, IEnumerable<Fact>>();
            var list1 = new List<Fact> {new Fact {FactId = "2"}, new Fact {FactId = "3"}};
            var list2 = new List<Fact> {new Fact {FactId = "4"}, new Fact {FactId = "1"}};
            dictionary.Add("1", list1);
            dictionary.Add("5", list2);
            _stringListDictionary = dictionary;
            _expected = new List<Anchor>();
            var anchor1 = new Anchor {Data = "1"};
            var anchor2 = new Anchor {Data = "2"};
            var anchor3 = new Anchor {Data = "3"};
            var anchor4 = new Anchor {Data = "4"};
            var anchor5 = new Anchor {Data = "5"};

            var anchorList1 = new List<Anchor> {anchor2, anchor3};
            var anchorList2 = new List<Anchor> {anchor4, anchor1};
            anchor1.Children = anchorList1;
            anchor5.Children = anchorList2;
            _expected.Add(anchor5);
        }

        private static IDictionary<string, IEnumerable<Fact>> _stringListDictionary;
        private static List<Anchor> _expected;

        [Test]
        public void ShouldGetChildForTheParentList()
        {
            var actual = ParentList.GetParentSet(_stringListDictionary);
            for (var i = 0; i < actual.Count; i++)
            {
                for (var j = 0; j < actual[i].Children.Count; j++)
                {
                    Assert.AreEqual(_expected[i].Children[j].Data, actual[i].Children[j].Data);
                }
            }
        }

        [Test]
        public void ShouldGetGrandParentIfAvailable()
        {
            var actual = ParentList.GetParentSet(_stringListDictionary);
            for (var i = 0; i < actual.Count; i++)
            {
                for (var j = 0; j < actual[i].Children.Count; j++)
                {
                    if (actual[i].Children[j].Children == null) continue;
                    for (var k = 0; k < actual[i].Children[j].Children.Count; k++)
                    {
                        var expected = _expected[i].Children[j].Children;
                        var real = actual[i].Children[j].Children;
                        Assert.AreEqual(expected[k].Data, real[k].Data);
                    }
                }
            }
        }

        [Test]
        public void ShouldGetParentList()
        {
            var actual = ParentList.GetParentSet(_stringListDictionary);
            for (var i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(_expected[i].Data, actual[i].Data);
            }
        }
    }
}