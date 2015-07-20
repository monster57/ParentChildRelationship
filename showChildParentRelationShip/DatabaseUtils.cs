using System.Data;
using MySql.Data.MySqlClient;

namespace ParentChildRelationship
{
    public class DatabaseUtils
    {
        private static MySqlConnection _mySqlConnection;

        private static MySqlConnection SingleConnection
        {
            get
            {
                if (_mySqlConnection != null) return _mySqlConnection;
                _mySqlConnection = CreateConnection();
                _mySqlConnection.Open();
                return _mySqlConnection;
            }
        }

        private static MySqlConnection CreateConnection()
        {
            return new MySqlConnection(new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "root",
                Database = "new_student"
            }.ToString());
        }

        

        public static DataTable ExecuteQuery(string query)
        {
            var connection = SingleConnection;
            var dataTable = new DataTable();
            new MySqlDataAdapter(new MySqlCommand(query, connection)).Fill(dataTable);
            return dataTable;
        }
    }
}