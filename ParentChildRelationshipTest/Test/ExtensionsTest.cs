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
            var datatable = Helper.GetStandardFactDataTable();
            var dataRow = datatable.NewRow();
            dataRow[ConfigSettings.WhatKey] = 59;
            dataRow[ConfigSettings.When3Key] = 5;
            dataRow[ConfigSettings.Where4Key] = 1;
            dataRow[ConfigSettings.How3Key] = 2;
            datatable.Rows.Add(dataRow);

            var listDataRows = new List<DataRow> {dataRow};
            Assert.AreEqual(listDataRows, datatable.GetDataRows());
        }

        [Test]
        public void GetValueTakesARowAndColumnNameReturnsTheValueOfThatColumnForThatRow()
        {
            var datatable = Helper.GetStandardFactDataTable();
            var factDimensions = new FactDimensions
            {
                Wherekey = "1",
                Whatkey = "59",
                Whenkey = "5",
                Howkey = "2"
            };
            var dataRow = Helper.GetStandardFactDataRow(datatable, factDimensions);
            datatable.Rows.Add(dataRow);
            const string expectedWhen3Key = "5";
            const string expectedWhere4Key = "1";
            const string expectedWhatKey = "59";
            const string expectedHow3Key = "2";

            Assert.AreEqual(dataRow.GetValue(ConfigSettings.When3Key), expectedWhen3Key);
            Assert.AreEqual(dataRow.GetValue(ConfigSettings.Where4Key), expectedWhere4Key);
            Assert.AreEqual(dataRow.GetValue(ConfigSettings.WhatKey), expectedWhatKey);
            Assert.AreEqual(dataRow.GetValue(ConfigSettings.How3Key), expectedHow3Key);
        }
    }
}