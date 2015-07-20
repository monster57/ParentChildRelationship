using System.Data;

namespace ParentChildRelationship
{
    public class FactDimensions
    {
        public string Whatkey { get; set; }
        public string Howkey { get; set; }
        public string Wherekey { get; set; }
        public string Whenkey { get; set; }

        public static FactDimensions GetFactDimensionsFromRow(DataRow row)
        {
            return new FactDimensions
            {
                Howkey = row.GetValue(Constants.AnchorHow3Key),
                Whatkey = row.GetValue(Constants.AnchorWhatKey),
                Wherekey = row.GetValue(Constants.AnchorWhere4Key),
                Whenkey = row.GetValue(Constants.When3Key)
            };
        }
    }
}