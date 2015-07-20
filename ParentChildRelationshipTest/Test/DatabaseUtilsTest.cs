using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    internal class DatabaseUtilsTest
    {
        [Test]
        public void ShouldGetADataTableFromDatabase()
        {
            const string query =
                "select WhatKey , When3Key , Where4Key , How3Key FROM new_student.fact_data_sheet1 where Fact_DataId = 133;";
            var datatable = FactData.GetStandardFactDataTable();
            var factDimension = new FactDimensions
            {
                Whatkey = "59",
                Whenkey = "5",
                Wherekey = "1",
                Howkey = "2"
            };
            datatable.Rows.Add(FactData.GetStandardFactDataRow(datatable , factDimension));
            var expected = datatable.GetDataRows().ToList();
            var actual = DatabaseUtils.ExecuteQuery(query).GetDataRows().ToList();
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}