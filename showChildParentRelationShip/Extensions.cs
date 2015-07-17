using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ParentChildRelationship
{
    public static class Extensions
    {
        public static string GetValue(this DataRow row, string columnName)
        {
            return row[columnName].ToString();
        }

        public static IEnumerable<DataRow> GetDataRows(this DataTable dataTable)
        {
            return dataTable.Rows.Cast<DataRow>();
        }
    }
}