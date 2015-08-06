using System.Collections.Generic;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Integration_Test
{
    [TestFixture]
    internal class RelationMapperTest
    {
        [SetUp]
        public void Init()
        {
            var map = new Dictionary<string, IEnumerable<Fact>>();
            var listFacts1 = new List<Fact>();
            var fact1 = new Fact { FactId = "2" };
            listFacts1.Add(fact1);
            
            var listFacts2 = new List<Fact>();
            var fact2 = new Fact { FactId = "3" };
            var fact3 = new Fact { FactId = "4" };
            listFacts2.Add(fact2);
            listFacts2.Add(fact3);

            var listFacts3 = new List<Fact>();
            var fact4 = new Fact { FactId = "5" };
            var fact5 = new Fact { FactId = "6" };
            listFacts3.Add(fact4);
            listFacts3.Add(fact5);
            
            map.Add("1", listFacts1);
            map.Add("2" , listFacts2);
            map.Add("3" , listFacts3);
            _list = ParentList.GetParentSet(map);

        }

        private  static List<Anchor> _list;

        [Test]
        public void ShouldGetAListOfAllRelationshipTree()
        {
            var expected = new List<RelationshipTree> {new RelationshipTree {Root = new Anchor {Data = "1"}}};


            var relationMapper = new RelationMapper(_list);
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Root.Data, relationMapper.GetRelationTreeList()[i].Root.Data);
            }
        }
    }
}