using System.Data;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    internal static class FactData
    {
        public static DataTable GetStandardFactDataTable()
        {
            var datatable = new DataTable();
            datatable.Columns.Add(Constants.Anchor + Constants.WhatKey);
            datatable.Columns.Add(Constants.When3Key);
            datatable.Columns.Add(Constants.Anchor + Constants.Where4Key);
            datatable.Columns.Add(Constants.Anchor + Constants.How3Key);
            return datatable;
        }

        public static DataRow GetStandardFactDataRow(DataTable dataTable, FactDimensions factDimension)
        {
            return GetStandardFactDataRow(dataTable, factDimension.Whatkey, factDimension.Whenkey,
                factDimension.Wherekey, factDimension.Howkey);
        }

        public static DataRow GetStandardFactDataRow(DataTable dataTable, string whatKey, string whenKey,
            string whereKey, string howKey)
        {
            var dataRow = dataTable.NewRow();
            dataRow[Constants.Anchor + Constants.WhatKey] = whatKey;
            dataRow[Constants.When3Key] = whenKey;
            dataRow[Constants.Anchor + Constants.Where4Key] = whereKey;
            dataRow[Constants.Anchor + Constants.How3Key] = howKey;
            return dataRow;
        }
    }
}