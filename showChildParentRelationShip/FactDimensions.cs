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
                Howkey = row.GetValue(Constants.Anchor + Constants.How3Key),
                Whatkey = row.GetValue(Constants.Anchor + Constants.WhatKey),
                Wherekey = row.GetValue(Constants.Anchor + Constants.Where4Key),
                Whenkey = row.GetValue(Constants.When3Key)
            };
        }
    }
}