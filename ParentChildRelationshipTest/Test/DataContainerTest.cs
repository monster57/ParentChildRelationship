using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    internal class DataContainerTest
    {
        [Test]
        public void ShouldGetADictionaryOfAllTheChildParentId()
        {
            var dictionary = new ParentChildUtil().GetParentToChildrenMap();
            const int totalKeyValuePair = 149;
            Assert.AreEqual(dictionary.Count, totalKeyValuePair);
        }
    }
}