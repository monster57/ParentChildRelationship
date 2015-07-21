using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    internal class FactDimensionTest
    {
        [Test]
        public void ShouldGetFactDimensionsFromDataRow()
        {
            var dataTable = FactData.GetStandardFactDataTable();
            const string whatKey = "59";
            const string whenKey = "5";
            const string whereKey = "1";
            const string howKey = "2";

            var factDimensions = new FactDimensions
            {
                Howkey = "2",
                Whatkey = "59",
                Whenkey = "5",
                Wherekey = "1"
            };
            var result =
                FactDimensions.GetFactDimensionsFromRow(FactData.GetStandardFactDataRow(dataTable, whatKey, whenKey,
                    whereKey, howKey));
            Assert.AreEqual(result.Howkey, factDimensions.Howkey);
            Assert.AreEqual(result.Wherekey, factDimensions.Wherekey);
            Assert.AreEqual(result.Whenkey, factDimensions.Whenkey);
            Assert.AreEqual(result.Whatkey, factDimensions.Whatkey);
        }
    }
}