namespace ParentChildRelationship
{
    public static class QueryCreator
    {
        private static string GetSelectClause(string id)
        {
            return "select "+id;
        }
        private static string GetDimensionWithPrefix(string category)
        {
            string[] dimension =
            {
                category + "." + ConfigSettings.When3Key, category + "." + category + ConfigSettings.How3Key,
                category + "." + category + ConfigSettings.WhatKey, category + "." + category + ConfigSettings.Where4Key
            };
            return string.Join(" , ", dimension)+" ";
        }
        private static string GetDimension(string category)
        {
            string[] dimension =
            {
                ConfigSettings.When3Key, category + ConfigSettings.How3Key,
                category + ConfigSettings.Where4Key, category + ConfigSettings.WhatKey
            };
            return string.Join(" , ", dimension)+" ";
        }
        private static string GetJoincaluse(string category)
        {
            return " on "+ConfigSettings.Fact + "." + ConfigSettings.WhatKey + " = " + category + "." + category +
                   ConfigSettings.WhatKey +
                   " and " + ConfigSettings.Fact + "." + ConfigSettings.How3Key + " = " + category + "." +
                   category + ConfigSettings.How3Key +
                   " and " + ConfigSettings.Fact + "." + ConfigSettings.When3Key + " = " + category + "." +
                   ConfigSettings.When3Key +
                   " and " + ConfigSettings.Fact + "." + ConfigSettings.Where4Key + " = " + category + "." +
                   category + ConfigSettings.Where4Key + ";";
        }
        private static string GetFromClause(string datatable)
        {
            return "from "+ConfigSettings.Schema+"." + datatable;
        }
        private static string GetWhereClause(FactDimensions dimensions)
        {            
            return " where "+ ConfigSettings.Anchor + ConfigSettings.WhatKey + " = " + dimensions.Whatkey +
            " and "+ConfigSettings.Anchor+ConfigSettings.Where4Key+" = " + dimensions.Wherekey +
            " and "+ConfigSettings.Anchor+ConfigSettings.How3Key+" = " + dimensions.Howkey +
            " and "+ConfigSettings.When3Key+" = " + dimensions.Whenkey;

        }
        public static string GetParentIdQuery()
        {
            return GetSelectClause(ConfigSettings.Fact+"."+ConfigSettings.Id) + " , "
                   + GetDimensionWithPrefix(ConfigSettings.Anchor)
                   + GetFromClause(ConfigSettings.FactDataTable) + " " + ConfigSettings.Fact + " join " +
                   "(select Distinct " + GetDimension(ConfigSettings.Anchor) +
                   GetFromClause(ConfigSettings.ParentChildTable) + ") " +
                    ConfigSettings.Anchor + GetJoincaluse(ConfigSettings.Anchor);
        }
        public static string GetChildIdQuery(FactDimensions factDimension)
        {
            return GetSelectClause(ConfigSettings.Fact + "." + ConfigSettings.Id) + " " + GetFromClause(ConfigSettings.FactDataTable) + " " + ConfigSettings.Fact +
                   " join (select " + GetDimension(ConfigSettings.Child) +
                   GetFromClause(ConfigSettings.ParentChildTable) +GetWhereClause(factDimension)+
                   ") "+ConfigSettings.Child + GetJoincaluse(ConfigSettings.Child);
        }
    }
}