using System.Data;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    class DatabaseUtilsTest
    {
        [Test]
        public void ExecuteQueryGivesADataTable()
        {
            const string query = "select WhatKey , When3Key , Where4Key , How3Key FROM new_student.fact_data_sheet1 where Fact_DataId = 133;";
            var datatable  = new DataTable();
            datatable.Columns.Add("WhatKey");
            datatable.Columns.Add("When3Key");
            datatable.Columns.Add("Where4Key");
            datatable.Columns.Add("How3Key");
            var dataRow = datatable.NewRow();
            dataRow["WhatKey"] = 59;
            dataRow["When3Key"] = 5;
            dataRow["Where4Key"] = 1;
            dataRow["How3Key"] = 2;
            datatable.Rows.Add(dataRow);
            var result = DatabaseUtils.ExecuteQuery(query);
            Assert.AreEqual(datatable.Rows[0].ItemArray[0] , result.Rows[0].ItemArray[0].ToString());
            Assert.AreEqual(datatable.Rows[0].ItemArray[1], result.Rows[0].ItemArray[1].ToString());
            Assert.AreEqual(datatable.Rows[0].ItemArray[2], result.Rows[0].ItemArray[2].ToString());
            Assert.AreEqual(datatable.Rows[0].ItemArray[3], result.Rows[0].ItemArray[3].ToString());

        }

    }
}
