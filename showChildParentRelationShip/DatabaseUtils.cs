using System.Data;
using MySql.Data.MySqlClient;

namespace ParentChildRelationship
{
    public class DatabaseUtils
    {
        public static DataTable ExecuteQuery(string query, MySqlConnection connection)
        {
            var dataTable = new DataTable();
            new MySqlDataAdapter(new MySqlCommand(query, connection)).Fill(dataTable);
            return dataTable;
        }
    }
}