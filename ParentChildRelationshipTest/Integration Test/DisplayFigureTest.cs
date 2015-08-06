using System.Collections.Generic;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Integration_Test
{
    [TestFixture]
    class DisplayFigureTest
    {
        [SetUp]
        public void Init()
        {
            var dictionary = new Dictionary<string , IEnumerable<Fact>>();
            var fact1 = new Fact{FactId = "1"};
            var fact2 = new Fact{FactId = "2"};
            var fact3 = new Fact{FactId = "3"};
            var fact4 = new Fact{FactId = "4"};
            dictionary.Add("1" , new List<Fact>{fact2 , fact3});
            dictionary.Add("5" , new List<Fact>{fact4 , fact1});
            var parentList = ParentList.GetParentSet(dictionary);
            _parentList = parentList;

            var expected = new List<List<string>>();
            var list1 = new List<string>{"5","4"};
            var list2 = new List<string>{"5","1","2"};
            var list3 = new List<string>{"5","1","3"};
            expected.Add(list1);
            expected.Add(list2);
            expected.Add(list3);
            _expected = expected;
        }

        private static List<Anchor> _parentList;
        private static List<List<string>> _expected;
        [Test]
        public void ShouldGetAListOfAllParentToTheLastChild()
        {
            var list = DisplayFigure.GetParentChildRepresentation(_parentList);
            for (var i = 0; i <_expected.Count ; i++)
            {
                Assert.AreEqual(list[i] , _expected[i]);
            }

        }

    }
}
