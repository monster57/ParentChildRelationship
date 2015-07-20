using System.Collections.Generic;
using System.Data;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    internal class ExtensionsTest
    {
        [Test]
        public void GetDataRowsTakesADatatableAndReturnsAListOfRows()
        {
            var datatable = FactData.GetStandardFactDataTable();
            var dataRow = datatable.NewRow();
            dataRow["AnchorWhatKey"] = 59;
            dataRow["When3Key"] = 5;
            dataRow["AnchorWhere4Key"] = 1;
            dataRow["AnchorHow3Key"] = 2;
            datatable.Rows.Add(dataRow);

            var listDataRows = new List<DataRow> {dataRow};
            Assert.AreEqual(listDataRows, datatable.GetDataRows());
        }

        [Test]
        public void GetValueTakesARowAndColumnNameReturnsTheValueOfThatColumnForThatRow()
        {
            var datatable = FactData.GetStandardFactDataTable();
            var factDimensions = new FactDimensions
            {
                Wherekey = "1",
                Whatkey = "59",
                Whenkey = "5",
                Howkey = "2"
            };
            var dataRow = FactData.GetStandardFactDataRow(datatable, factDimensions);
            datatable.Rows.Add(dataRow);
            const string expectedWhen3Key = "5";
            const string expectedWhere4Key = "1";
            const string expectedWhatKey = "59";
            const string expectedHow3Key = "2";

            Assert.AreEqual(dataRow.GetValue(Constants.When3Key), expectedWhen3Key);
            Assert.AreEqual(dataRow.GetValue(Constants.Anchor + Constants.Where4Key), expectedWhere4Key);
            Assert.AreEqual(dataRow.GetValue(Constants.Anchor + Constants.WhatKey), expectedWhatKey);
            Assert.AreEqual(dataRow.GetValue(Constants.Anchor + Constants.How3Key), expectedHow3Key);
        }
    }
}