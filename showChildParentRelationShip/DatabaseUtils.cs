using System.Configuration;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using MySql.Data.MySqlClient;

namespace ParentChildRelationship
{
    public class DatabaseUtils
    {
        public static DataTable ExecuteQuery(string query, SqlConnectionWrapper connection)
        {
            var dataTable = new DataTable();
            new MySqlDataAdapter(new MySqlCommand(query, connection.SqlConnection)).Fill(dataTable);
            ConnectionPool.ReturnConnection(connection);
            return dataTable;
        }
    }
}