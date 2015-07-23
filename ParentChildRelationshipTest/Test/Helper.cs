using System.Data;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    internal static class Helper
    {
        public static DataTable GetStandardFactDataTable()
        {
            var datatable = new DataTable();
            datatable.Columns.Add(ConfigSettings.AnchorWhatKey);
            datatable.Columns.Add(ConfigSettings.When3Key);
            datatable.Columns.Add(ConfigSettings.AnchorWhere4Key);
            datatable.Columns.Add(ConfigSettings.AnchorHow3Key);
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
            dataRow[ConfigSettings.AnchorWhatKey] = whatKey;
            dataRow[ConfigSettings.When3Key] = whenKey;
            dataRow[ConfigSettings.AnchorWhere4Key] = whereKey;
            dataRow[ConfigSettings.AnchorHow3Key] = howKey;
            return dataRow;
        }
    }
}