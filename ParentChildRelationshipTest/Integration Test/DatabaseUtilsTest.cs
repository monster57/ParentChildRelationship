using System.Linq;
using NUnit.Framework;
using ParentChildRelationship;
using ParentChildRelationshipTest.Test;

namespace ParentChildRelationshipTest.Integration_Test
{
    [TestFixture]
    internal class DatabaseUtilsTest
    {
        [Test]
        public void ShouldGetADataTableFromDatabase()
        {
            var query = "select " + ConfigSettings.WhatKey + " , " + ConfigSettings.When3Key + " , " + ConfigSettings.Where4Key + " , " + ConfigSettings.How3Key + " FROM " + 
                ConfigSettings.Schema + "." +ConfigSettings.FactDataTable+ " where "+ConfigSettings.Id+" = 133;";
            var datatable = Helper.GetStandardFactDataTable();
            var factDimension = new FactDimensions
            {
                Whatkey = "59",
                Whenkey = "5",
                Wherekey = "1",
                Howkey = "2"
            };
            datatable.Rows.Add(Helper.GetStandardFactDataRow(datatable , factDimension));
            var expected = datatable.GetDataRows().ToList();
            var actual = DatabaseUtils.ExecuteQuery(query).GetDataRows().ToList();
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}