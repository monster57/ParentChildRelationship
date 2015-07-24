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
            var expected = new List<Fact> {new Fact {FactId = "432"}};
            IEnumerable<Fact> factList;
            var dictionary = new ParentChildUtil().GetParentToChildrenMap();
            var parentId = "424";
            dictionary.TryGetValue(parentId, out factList);
            if (factList == null) return;
            var actual = factList as List<Fact> ?? factList.ToList();
            for (var index = 0; index < actual.Count; index++)
            {
                Assert.AreEqual(actual[index].FactId, expected[index].FactId);
            }
        }
    }
}