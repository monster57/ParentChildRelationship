namespace ParentChildRelationship
{
    public static class QueryCreator
    {
        private static string GetSelectDistinctClause(string id)
        {
            return "select distinct " + id+" ";
        }

        private static string GetFromClause(string datatable)
        {
            return "from " + ConfigSettings.Schema + "." + datatable+" ";
        }
        private static string GetJoinClause(string dataTable)
        {
            return " join " + ConfigSettings.Schema + "." + dataTable + " ";
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

        private static string GetOncaluse(string dependentTable , string category , string prefix)
        {
            return " on " + dependentTable + "." + ConfigSettings.WhatKey + " = " + category + "." + prefix +
                   ConfigSettings.WhatKey +
                   " and " + dependentTable + "." + ConfigSettings.How3Key + " = " + category + "." +
                   prefix + ConfigSettings.How3Key +
                   " and " + dependentTable + "." + ConfigSettings.When3Key + " = " + category + "." +
                   ConfigSettings.When3Key +
                   " and " + dependentTable + "." + ConfigSettings.Where4Key + " = " + category + "." +
                   prefix + ConfigSettings.Where4Key + ";";
        }

        private static string GetOnClauseOnValue(string depentdentTable , string prefix , FactDimensions fact)
        {
            return " on " + depentdentTable + "." + prefix + ConfigSettings.WhatKey + " = " + fact.Whatkey +
                   " and " + depentdentTable + "." + prefix + ConfigSettings.How3Key + "  = " + fact.Howkey +
                   " and " + depentdentTable + "." + ConfigSettings.When3Key + " = " + fact.Whenkey +
                   " and " + depentdentTable + "." + prefix + ConfigSettings.Where4Key + " = " + fact.Wherekey;
        }

        private static string GetConditionForStar(string dependentTable , string category  , string prefix)
        {
            return " and ( " + dependentTable + "." + ConfigSettings.WhatKey + " = " + category + "." + prefix +
                   ConfigSettings.WhatKey +
                   " or " + category + "." + prefix + ConfigSettings.WhatKey + " = '*') " +
                   "and ( " + dependentTable + "." + ConfigSettings.Where4Key + " = " + category + "." + prefix +
                   ConfigSettings.Where4Key +
                   " or " + category + "." + prefix + ConfigSettings.Where4Key + " = '*') " +
                   "and ( " + dependentTable + "." + ConfigSettings.How3Key + " = " + category + "." + prefix +
                   ConfigSettings.How3Key +
                   " or " + category + "." + prefix + ConfigSettings.How3Key + " = '*') " +
                   "and "+dependentTable+ "."+ ConfigSettings.When3Key+" = "+category + "."+ConfigSettings.When3Key +";";
        }
        
        public static string GetParentIdQuery()
        {
            return GetSelectDistinctClause(ConfigSettings.Fact+"."+ConfigSettings.Id)+", "+GetDimensionWithOrigin(ConfigSettings.Fact)+
                   GetFromClause(ConfigSettings.FactDataTable)+ConfigSettings.Fact+
                   GetJoinClause(ConfigSettings.ParentChildTable)+ConfigSettings.Child+
                   GetOncaluse( ConfigSettings.Fact,ConfigSettings.Child , ConfigSettings.Anchor);
        }

        public static string GetChildIdQuery(FactDimensions factDimension)
        {
            return GetSelectDistinctClause(ConfigSettings.Fact + "." + ConfigSettings.Id) + 
                   GetFromClause(ConfigSettings.FactDataTable)+ConfigSettings.Fact+
                   GetJoinClause(ConfigSettings.ParentChildTable)+ConfigSettings.Child+
                   GetOnClauseOnValue(ConfigSettings.Child , ConfigSettings.Anchor , factDimension)+
                   GetConditionForStar(ConfigSettings.Fact , ConfigSettings.Child , ConfigSettings.Child);
        }
    }
}