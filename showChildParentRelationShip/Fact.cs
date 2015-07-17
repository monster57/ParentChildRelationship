using System.Data;

namespace ParentChildRelationship
{
    public class Fact
    {
        public string FactId { get; set; }

        public static Fact GetFactFromRow(DataRow row)
        {
            return new Fact
            {
                FactId = row.GetValue(Constants.FactDataId)
            };
        }
    }
}