using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Integration_Test
{
    [TestFixture]
    internal class DataContainerTest
    {
        [Test]
        public void ShouldGetChildIdBelongsToTheParentId()
        {
            var expected = new List<Fact> {new Fact {FactId = "474"}};
            IEnumerable<Fact> factList;
            var dictionary = new ParentChildUtil().GetParentToChildrenMap();
            const string parentId = "473";
            dictionary.TryGetValue(parentId, out factList);

            var enumerable = factList as List<Fact> ?? factList.ToList();
            for (var i = 0; i < enumerable.Count; i++)
            {
                Assert.AreEqual(enumerable[i].FactId, expected[i].FactId);
            }

            
        }
    }
}