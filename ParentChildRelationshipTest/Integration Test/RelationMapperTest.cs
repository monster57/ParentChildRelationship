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
            _map = new Dictionary<string, IEnumerable<Fact>>();
            var listFacts1 = new List<Fact>();
            var listFacts2 = new List<Fact>();
            var listFacts3 = new List<Fact>();
            var fact1 = new Fact {FactId = "2"};
            var fact2 = new Fact {FactId = "3"};
            var fact3 = new Fact {FactId = "4"};
            var fact4 = new Fact { FactId = "5" };
            var fact5 = new Fact { FactId = "6" };
            listFacts1.Add(fact1);
            _map.Add("1", listFacts1);
            listFacts2.Add(fact2);
            listFacts2.Add(fact3);

            listFacts3.Add(fact4);
            listFacts3.Add(fact5);
            _map.Add("2" , listFacts2);
            _map.Add("3" , listFacts3);

        }

        private  static IDictionary<string, IEnumerable<Fact>> _map;

        [Test]
        public void ShouldGetAListOfRelatedFactIdFromADictionary()
        {
            var expected = new List<List<string>>();

            var stringList1 = new List<string> {"1", "2" , "3", "5"};
            var stringList2 = new List<string> {"1", "2" , "3", "6"};
            var stringList3 = new List<string> { "1", "2", "4" };
            expected.Add(stringList1);
            expected.Add(stringList2);
            expected.Add(stringList3);
            var relationMapper = new RelationMapper(_map);
            Assert.AreEqual(expected, relationMapper.GiveRelationList());
        }
    }
}