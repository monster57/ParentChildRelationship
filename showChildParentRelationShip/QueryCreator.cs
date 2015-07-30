namespace ParentChildRelationship
{
    public static class QueryCreator
    {
        private static string GetSelectClause(string id)
        {
            return "select " + id;
        }

        private static string GetDimensionWithPrefix(string category)
        {
            string[] dimension =
            {
                category + "." + ConfigSettings.When3Key, category + "." + category + ConfigSettings.How3Key,
                category + "." + category + ConfigSettings.WhatKey, category + "." + category + ConfigSettings.Where4Key
            };
            return string.Join(" , ", dimension) + " ";
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

        private static string GetJoincaluse(string category)
        {
            return " on " + ConfigSettings.Fact + "." + ConfigSettings.WhatKey + " = " + category + "." + category +
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
            return "from " + ConfigSettings.Schema + "." + datatable;
        }

        private static string GetWhereClause(FactDimensions dimensions)
        {
            return " where " + ConfigSettings.Anchor + ConfigSettings.WhatKey + " = " + dimensions.Whatkey +
                   " and " + ConfigSettings.Anchor + ConfigSettings.Where4Key + " = " + dimensions.Wherekey +
                   " and " + ConfigSettings.Anchor + ConfigSettings.How3Key + " = " + dimensions.Howkey +
                   " and " + ConfigSettings.When3Key + " = " + dimensions.Whenkey;
        }

        public static string GetParentIdQuery()
        {
            return GetSelectClause(ConfigSettings.Fact + "." + ConfigSettings.Id) + " , "
                   + GetDimensionWithPrefix(ConfigSettings.Anchor)
                   + GetFromClause(ConfigSettings.FactDataTable) + " " + ConfigSettings.Fact + " join " +
                   "(select Distinct " + GetDimension(ConfigSettings.Anchor) +
                   GetFromClause(ConfigSettings.ParentChildTable) + ") " +
                   ConfigSettings.Anchor + GetJoincaluse(ConfigSettings.Anchor);
        }

        public static string GetChildIdQuery(FactDimensions factDimension)
        {
            return "select fact.id from fact_dimension_relationship.fact_data fact " +
                               "join (select distinct tab.childWhatKey , tab.childHow3Key , child.childWhere4Key , tab.When3Key " +
                               "from fact_dimension_relationship.parent_child_data child join " +
                               "(select distinct tab.childWhatKey , child.childHow3Key , tab.childWhere4Key , tab.When3Key " +
                               "from fact_dimension_relationship.parent_child_data child join " +
                               "(select distinct child.childWhatKey , tab.childHow3Key , tab.childWhere4Key , tab.When3Key " +
                               "from fact_dimension_relationship.parent_child_data child join " +
                               "(select when3Key , childhow3Key , childwhere4Key , childwhatKey from " +
                               "fact_dimension_relationship.parent_child_data where anchorwhatKey = " + factDimension.Whatkey +
                               " and anchorwhere4Key = " + factDimension.Wherekey +
                               " and anchorhow3Key = " + factDimension.Howkey +
                               " and when3Key = " + factDimension.Whenkey +
                               ") tab " +
                               "on child.childWhatkey = tab.childwhatkey " +
                               "or tab.childwhatkey = '*' " +
                               "where child.childwhatkey !='*') tab on child.childHow3Key = tab.childHow3Key " +
                               "or tab.childHow3Key = '*' " +
                               "where child.childHow3Key!='*') tab " +
                               "on child.childWhere4Key = tab.childWhere4Key " +
                               "or tab.childWhere4Key = '*' " +
                               "where child.childWhere4Key !='*') child " +
                               "on fact.whatKey = child.childwhatKey and fact.how3Key = child.childhow3Key " +
                               "and fact.when3Key = child.when3Key and fact.where4Key = child.childwhere4Key";

        }
    }
}