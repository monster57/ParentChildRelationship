using System;
using System.Linq;
using System.Text;

namespace ParentChildRelationship
{
    public static class QueryCreator
    {

        private static string GetSelect()
        {
            return "select fact.Fact_DataId";
        }

        private static string GetDimensionWithPrefix(string category)
        {
            string[] dimension =
            {
                category + "." + Constants.When3Key, category + "." + category+Constants.How3Key,
                category + "." + category+Constants.WhatKey, category + "." + category + Constants.Where4Key
            };


            return string.Join(" , ", dimension);
        }

        private static string GetDimension(string category)
        {
            string[] dimension =
            {
                 Constants.When3Key, category+Constants.How3Key,
                 category+Constants.Where4Key,  category + Constants.WhatKey          
            };
            return string.Join(" , ", dimension);
        }

        
        private static string Something(string category)
        {
            return Constants.Fact + "." + Constants.WhatKey + " = " + category + "." + category+
                   Constants.WhatKey +
                   " and " + Constants.Fact + "." + Constants.How3Key + " = " + category + "." +
                   category + Constants.How3Key +
                   " and " + Constants.Fact + "." + Constants.When3Key + " = " + category+ "." +
                   Constants.When3Key +
                   " and " + Constants.Fact + "." + Constants.Where4Key + " = " + category+ "." +
                   category + Constants.Where4Key+";";
        }

        private static string GetFrom(string datatable)
        {
            return "from new_student." + datatable;
        }

        public static string GetParentIdQuery()
        {
            return GetSelect() + " , "
                   + GetDimensionWithPrefix(Constants.Anchor) + " "
                   +GetFrom(Constants.FactDataTable)+" "+Constants.Fact+" join " +
                   "(select Distinct " + GetDimension(Constants.Anchor) +
                   " "+GetFrom(Constants.ParentChildtable)+")" +
                   " "+Constants.Anchor+" " +
                   "on " + Something(Constants.Anchor);
        }
            

        public static string GetChildIdQuery(FactDimensions factDimension)
        {
            //return GetSelect()+" from new_student.fact_data_sheet1 fact "+
            // "join (SELECT "+GetDimension(Constants.Child) FROM "
            return GetSelect() + " "+GetFrom(Constants.FactDataTable)+" " +Constants.Fact+
                   " join (SELECT " + GetDimension(Constants.Child) +
                   " "+GetFrom(Constants.ParentChildtable)+" where AnchorWhatKey= " + factDimension.Whatkey +
                   " and AnchorWhere4Key = " + factDimension.Wherekey +
                   " and AnchorHow3Key = " + factDimension.Howkey +
                   " and When3Key = " + factDimension.Whenkey +
                   ") Child on " + Something(Constants.Child);
        }
    }
}