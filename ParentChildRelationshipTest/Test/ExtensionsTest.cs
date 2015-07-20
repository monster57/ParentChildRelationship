using System.Collections.Generic;
using System.Data;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    class ExtensionsTest
    {
        [Test]
        public void GetValueTakesARowAndColumnNameReturnsTheValueOfThatColumnForThatRow()
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

            Assert.AreEqual(dataRow.GetValue("When3Key"), "5");
            Assert.AreEqual(dataRow.GetValue("AnchorWhere4Key"), "1");
            Assert.AreEqual(dataRow.GetValue("AnchorWhatKey"), "59");
            Assert.AreEqual(dataRow.GetValue("AnchorHow3Key"), "2");


        }

        [Test]
        public void GetDataRowsTakesADatatableAndReturnsAListOfRows()
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

            var listDataRows = new List<DataRow> {dataRow};
            Assert.AreEqual(listDataRows , datatable.GetDataRows());
        }
    }
}
