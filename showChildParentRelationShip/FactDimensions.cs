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
                Howkey = row.GetValue(ConfigSettings.How3Key),
                Whatkey = row.GetValue(ConfigSettings.WhatKey),
                Wherekey = row.GetValue(ConfigSettings.Where4Key),
                Whenkey = row.GetValue(ConfigSettings.When3Key)
            };
        }
    }
}