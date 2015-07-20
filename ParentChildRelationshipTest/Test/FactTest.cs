using System.Data;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    class FactTest
    {
        [Test]
        public void ShouldGetFactFromADataRow()
        {
            var datatable = FactData.GetStandardFactDataTable();
            datatable.Columns.Add(Constants.FactDataId);
            var dataRow = datatable.NewRow();
            dataRow[Constants.FactDataId] = 1;
            datatable.Rows.Add(dataRow);
            var result = Fact.GetFactFromRow(dataRow);
            var fact = new Fact {FactId = "1"};
            Assert.AreEqual(fact.FactId , result.FactId);
        }

    }
}
