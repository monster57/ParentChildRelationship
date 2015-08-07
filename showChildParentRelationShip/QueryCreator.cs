namespace ParentChildRelationship
{
    public static class QueryCreator
    {

        private static string GetSelectDistinctClause(string id)
        {
            return ConfigSettings.Select +ConfigSettings.Distinct+ id+" ";
        }

        private static string GetFromClause(string datatable)
        {
            return ConfigSettings.From + ConfigSettings.Schema + "." + datatable+" ";
        }
        private static string GetJoinClause(string dataTable)
        {
            return ConfigSettings.Join + ConfigSettings.Schema + "." + dataTable + " ";
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
            return ConfigSettings.On + dependentTable + "." + ConfigSettings.WhatKey + " = " + category + "." + prefix +
                   ConfigSettings.WhatKey +
                   ConfigSettings.And + dependentTable + "." + ConfigSettings.How3Key + " = " + category + "." +
                   prefix + ConfigSettings.How3Key +
                   ConfigSettings.And + dependentTable + "." + ConfigSettings.When3Key + " = " + category + "." +
                   ConfigSettings.When3Key +
                   ConfigSettings.And + dependentTable + "." + ConfigSettings.Where4Key + " = " + category + "." +
                   prefix + ConfigSettings.Where4Key + ";";
        }

        private static string GetOnClauseOnValue(string depentdentTable , string prefix , FactDimensions fact)
        {
            return ConfigSettings.On + depentdentTable + "." + prefix + ConfigSettings.WhatKey + " = " + fact.Whatkey +
                   ConfigSettings.And + depentdentTable + "." + prefix + ConfigSettings.How3Key + "  = " + fact.Howkey +
                   ConfigSettings.And + depentdentTable + "." + ConfigSettings.When3Key + " = " + fact.Whenkey +
                   ConfigSettings.And + depentdentTable + "." + prefix + ConfigSettings.Where4Key + " = " + fact.Wherekey;
        }

        private static string GetConditionForStar(string dependentTable , string category  , string prefix)
        {
            return ConfigSettings.And + "( " + dependentTable + "." + ConfigSettings.WhatKey + " = " + category + "." + prefix +
                   ConfigSettings.WhatKey +
                   ConfigSettings.Or + category + "." + prefix + ConfigSettings.WhatKey + " = '*')" +
                   ConfigSettings.And + "( " + dependentTable + "." + ConfigSettings.Where4Key + " = " + category + "." + prefix +
                   ConfigSettings.Where4Key +
                   ConfigSettings.Or + category + "." + prefix + ConfigSettings.Where4Key + " = '*')" +
                   ConfigSettings.And +"( " + dependentTable + "." + ConfigSettings.How3Key + " = " + category + "." + prefix +
                   ConfigSettings.How3Key +
                   ConfigSettings.Or + category + "." + prefix + ConfigSettings.How3Key + " = '*')" +
                   ConfigSettings.And + dependentTable + "." + ConfigSettings.When3Key + " = " + category + "." + ConfigSettings.When3Key + ";";
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