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
                Howkey = row.GetValue(ConfigSettings.AnchorHow3Key),
                Whatkey = row.GetValue(ConfigSettings.AnchorWhatKey),
                Wherekey = row.GetValue(ConfigSettings.AnchorWhere4Key),
                Whenkey = row.GetValue(ConfigSettings.When3Key)
            };
        }
    }
}