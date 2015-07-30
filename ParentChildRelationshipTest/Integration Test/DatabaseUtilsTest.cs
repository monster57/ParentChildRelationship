using System;
using System.Configuration;
using System.Linq;
using NUnit.Framework;
using ParentChildRelationship;
using ParentChildRelationshipTest.Test;

namespace ParentChildRelationshipTest.Integration_Test
{
    [TestFixture]
    internal class DatabaseUtilsTest
    {
        [SetUp] 
        public void Init()
        {
            _numberOfConnections = Convert.ToInt32(ConfigurationManager.AppSettings["degreeOfParallelism"]);
            ConnectionPool.Initialize(_numberOfConnections);
        }

        private int _numberOfConnections;

        [Test]
        public void ShouldGetADataTableFromDatabase()
        {
            var query = "select " + ConfigSettings.WhatKey + " , " + ConfigSettings.When3Key + " , " +
                        ConfigSettings.Where4Key + " , " + ConfigSettings.How3Key + " FROM " +
                        ConfigSettings.Schema + "." + ConfigSettings.FactDataTable + " where " + ConfigSettings.Id +
                        " = 133" + " or " + ConfigSettings.Id + " = 306;";
            var datatable = Helper.GetStandardFactDataTable();
            var factDimension = new FactDimensions
            {
                Whatkey = "59",
                Whenkey = "5",
                Wherekey = "1",
                Howkey = "2"
            };
            var factDimension1 = new FactDimensions
            {
                Whatkey = "71",
                Whenkey = "2",
                Wherekey = "1",
                Howkey = "2"
            };
            datatable.Rows.Add(Helper.GetStandardFactDataRow(datatable, factDimension));
            datatable.Rows.Add(Helper.GetStandardFactDataRow(datatable, factDimension1));

            var expected = datatable.GetDataRows().ToList();
            var actual = ConnectionPool.Execute(query).GetDataRows().ToList();
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}