using System.Data;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    class FactDimensionTest
    {
        [Test]
        public void GetFactDimensionFromRowTakesARowGivesAllDimensionOfFactFromThatRow()
        {
            var datatable = new DataTable();
            datatable.Columns.Add("AnchorWhatKey");
            datatable.Columns.Add("When3Key");
            datatable.Columns.Add("AnchorWhere4Key");
            datatable.Columns.Add("AnchorHow3Key");
            var dataRow = datatable.NewRow();
            dataRow["AnchorWhatKey"] = 59;
            dataRow["When3Key"] = 5;
            dataRow["AnchorWhere4Key"] = 1;
            dataRow["AnchorHow3Key"] = 2;
            datatable.Rows.Add(dataRow);

            var factDimention = new FactDimensions
            {
                Howkey = "2",
                Whatkey = "59",
                Whenkey = "5",
                Wherekey = "1"
            };

            var result = FactDimensions.GetFactDimensionsFromRow(datatable.Rows[0]);
            Assert.AreEqual(result.Howkey , factDimention.Howkey);
            Assert.AreEqual(result.Wherekey, factDimention.Wherekey);
            Assert.AreEqual(result.Whenkey, factDimention.Whenkey);
            Assert.AreEqual(result.Whatkey, factDimention.Whatkey);


        }
    }
}
