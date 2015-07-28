using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    internal class FactTest
    {
        [Test]
        public void ShouldGetFactFromADataRow()
        {
            var datatable = Helper.GetStandardFactDataTable();
            datatable.Columns.Add(ConfigSettings.Id);
            var dataRow = datatable.NewRow();
            dataRow[ConfigSettings.Id] = 1;
            datatable.Rows.Add(dataRow);
            var result = Fact.GetFactFromRow(dataRow);
            var fact = new Fact {FactId = "1"};
            Assert.AreEqual(fact.FactId, result.FactId);
        }
    }
}