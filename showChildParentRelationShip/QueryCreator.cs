using System;
using System.Text;

namespace ParentChildRelationShip
{
    public class QueryCreator
    {
        public string GetParentIdQuery()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("select fact.Fact_DataId , parent.AnchorHow3Key , parent.When3Key , parent.AnchorWhatKey ");
            stringBuilder.Append(", parent.AnchorWhere4Key from new_student.fact_data_sheet1 fact join (");
            stringBuilder.Append("select Distinct AnchorHow3Key , AnchorWhatKey , AnchorWhere4Key , When3Key from ");
            stringBuilder.Append("new_student.parentchild_sheet1) parent on fact.WhatKey = parent.AnchorWhatKey and fact.How3Key ");
            stringBuilder.Append(
                " = parent.AnchorHow3Key and fact.When3Key = parent.When3Key and parent.AnchorWhere4Key = parent.AnchorWhere4Key;");
            return stringBuilder.ToString();

        }

        public string GetChildIdQuery(Dimensions dimension)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("select fact.Fact_DataId from new_student.fact_data_sheet1 fact ");
            stringBuilder.Append("join  (SELECT ChildHow3Key , ChildWhatKey , ChildWhere4Key , When3Key FROM ");
            stringBuilder.Append("new_student.parentchild_sheet1 where AnchorWhatKey= ");
            stringBuilder.Append(dimension.Whatkey);
            stringBuilder.Append(" and AnchorWhere4Key = ");
            stringBuilder.Append(dimension.Wherekey);
            stringBuilder.Append(" and AnchorHow3Key = ");
            stringBuilder.Append(dimension.Howkey);
            stringBuilder.Append(" and When3Key = ");
            stringBuilder.Append(dimension.Whenkey);
            stringBuilder.Append(") child on fact.WhatKey = child.ChildWhatKey and fact.How3Key = child.ChildHow3Key ");
            stringBuilder.Append("and fact.When3Key = child.When3Key and fact.Where4Key = child.ChildWhere4Key;");
            return stringBuilder.ToString();

        }
 
    }
}