using System.Text;

namespace showChildParentRelationShip
{
    public class QueryCreator
    {
        public string GetParentDetailQuery(string id )
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT Where4Key  , WhatKey , How3Key , when3key FROM new_student.fact_data_sheet1 where Fact_DataId =");
            queryBuilder.Append(id);
            return queryBuilder.ToString();
            
        }

        public string GetAllParentDataQuery()
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append(
                "select Distinct AnchorHow3Key , AnchorWhatKey , AnchorWhere4Key , When3Key from new_student.parentchild_sheet1 ;");
            return queryBuilder.ToString();
        }

        public string GetParentId(string when3Key , string howKey , string whereKey ,  string whatKey )
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("select Fact_DataId from new_student.fact_data_sheet1 where When3Key = ");
            queryBuilder.Append(when3Key);
            queryBuilder.Append(" and How3Key = ");
            queryBuilder.Append(howKey);
            queryBuilder.Append(" and WhatKey = ");
            queryBuilder.Append(whatKey);
            queryBuilder.Append(" and Where4Key = ");
            queryBuilder.Append(whereKey);
            return queryBuilder.ToString();
        }

        public string GetChildDetails(string anchorHowKey, string anchorWhatKey, string anchorWhereKey, string when3Key)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append(
                "select ChildHow3Key , ChildWhatKey , ChildWhere4Key , when3key from new_student.parentchild_sheet1 where AnchorHow3Key = ");
            queryBuilder.Append(anchorHowKey);
            queryBuilder.Append(" and  AnchorWhatKey = ");
            queryBuilder.Append(anchorWhatKey);
            queryBuilder.Append(" and AnchorWhere4Key =");
            queryBuilder.Append(anchorWhereKey);
            queryBuilder.Append(" and when3key = ");
            queryBuilder.Append(when3Key);
            queryBuilder.Append(";");
            return queryBuilder.ToString();
        }

        public string GetChildIdQuery(Dimensions chilDimension)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("select Fact_DataId from new_student.fact_data_sheet1 where When3Key = ");
            queryBuilder.Append(chilDimension.Whenkey);
            queryBuilder.Append("  and How3Key = ");
            queryBuilder.Append(chilDimension.Howkey);
            queryBuilder.Append(" and WhatKey = ");
            queryBuilder.Append(chilDimension.Whatkey);
            queryBuilder.Append(" and Where4Key = ");
            queryBuilder.Append(chilDimension.Wherekey);
            queryBuilder.Append(" ;");
            return queryBuilder.ToString();
        } 
    }
}