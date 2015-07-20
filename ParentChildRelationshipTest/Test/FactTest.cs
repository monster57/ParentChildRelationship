using System.Data;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    class FactTest
    {
        [Test]
        public void GetFactFromRowGivesFactOfThatRow()
        {
            var datatable = new DataTable();
            datatable.Columns.Add("Fact_DataID");
            var dataRow = datatable.NewRow();
            dataRow["Fact_DataID"] = 1;
            datatable.Rows.Add(dataRow);

            var result = Fact.GetFactFromRow(dataRow);
            var fact = new Fact {FactId = "1"};
            Assert.AreEqual(fact.FactId , result.FactId);
        }

    }
}
