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

            var expected = new List<string>();
            var tree = "5   " + (char)26 + " 4  \n    "+(char)26 +" 1   " + (char)26 + " 2  \n          "+(char)26 + " 3  \n         ";
            
            expected.Add(tree);
            _expected = expected;
        }

        private static List<Anchor> _parentList;
        private static List<string> _expected;
        [Test]
        public void ShouldGetATreeOfAllParentToTheLastChild()
        {
            var list = DisplayFigure.GetParentChildRepresentation(_parentList);
            for (var i = 0; i <_expected.Count ; i++)
            {
                Assert.AreEqual(_expected[i], list[i]);
            }

        }

    }
}
