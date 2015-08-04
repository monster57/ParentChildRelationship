namespace ParentChildRelationship
{
    public static class QueryCreator
    {
        private static string GetSelectDistinctClause(string id)
        {
            return "select distinct " + id;
        }

        private static string GetFromClause(string datatable)
        {
            return "from " + ConfigSettings.Schema + "." + datatable+" ";
        }

        private static string GetWhereClause(FactDimensions dimensions)
        {
            return " where " + ConfigSettings.Anchor + ConfigSettings.WhatKey + " = " + dimensions.Whatkey +
                   " and " + ConfigSettings.Anchor + ConfigSettings.Where4Key + " = " + dimensions.Wherekey +
                   " and " + ConfigSettings.Anchor + ConfigSettings.How3Key + " = " + dimensions.Howkey +
                   " and " + ConfigSettings.When3Key + " = " + dimensions.Whenkey;
        }

        private static string GetDimensionWithOrigin(string category)
        {
            string[] dimension =
            {
                category + "." + ConfigSettings.When3Key, category + "." +  ConfigSettings.How3Key,
                category + "."  + ConfigSettings.WhatKey, category + "." + ConfigSettings.Where4Key
            };
            return string.Join(" , ", dimension) + " ";
        }

        private static string GetOncaluse(string category , string prefix)
        {
            return " on " + ConfigSettings.Fact + "." + ConfigSettings.WhatKey + " = " + category + "." + prefix +
                   ConfigSettings.WhatKey +
                   " and " + ConfigSettings.Fact + "." + ConfigSettings.How3Key + " = " + category + "." +
                   prefix + ConfigSettings.How3Key +
                   " and " + ConfigSettings.Fact + "." + ConfigSettings.When3Key + " = " + category + "." +
                   ConfigSettings.When3Key +
                   " and " + ConfigSettings.Fact + "." + ConfigSettings.Where4Key + " = " + category + "." +
                   prefix + ConfigSettings.Where4Key + ";";
        }

        private static string GetDimension(string category)
        {
            string[] dimension =
            {
                ConfigSettings.When3Key, category + ConfigSettings.How3Key,
                category + ConfigSettings.Where4Key, category + ConfigSettings.WhatKey
            };
            return string.Join(" , ", dimension) + " ";
        }

        private static string GetJoinClause(string dataTable)
        {
            return "join " + ConfigSettings.Schema + "." + dataTable+" ";
        }
        public static string GetParentIdQuery()
        {
            return GetSelectDistinctClause(ConfigSettings.Fact+"."+ConfigSettings.Id)+" , "+GetDimensionWithOrigin(ConfigSettings.Fact)+
                   GetFromClause(ConfigSettings.FactDataTable)+ConfigSettings.Fact+" "+
                   GetJoinClause(ConfigSettings.ParentChildTable)+ConfigSettings.Child+
                   GetOncaluse(ConfigSettings.Child , ConfigSettings.Anchor);
        }

        public static string GetChildIdQuery(FactDimensions factDimension)
        {
            return "select distinct fact.id " +
                   "from fact_dimension_relationship.fact_data fact " +
                   "join fact_dimension_relationship.parent_child_data child " +
                   "on ( fact.WhatKey = child.childWhatKey or child.childWhatKey = '*') " +
                   "and ( fact.Where4Key = child.childWhere4Key or child.childWhere4Key = '*') " +
                   "and ( fact.How3Key = child.childHow3Key or child.childHow3Key = '*' ) " +
                   "and fact.When3Key = child.When3Key " +
                   "and child.anchorwhatKey = " + factDimension.Whatkey +
                   " and child.anchorwhere4Key = " + factDimension.Wherekey +
                   " and child.anchorhow3Key = " + factDimension.Howkey +
                   " and child.when3Key = " + factDimension.Whenkey + ";";
        }
    }
}