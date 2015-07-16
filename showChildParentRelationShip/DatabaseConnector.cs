using MySql.Data.MySqlClient;

namespace showChildParentRelationShip
{
    public class DatabaseConnector
    {
        public MySqlConnection CreateConnection()
        {
            return new MySqlConnection(new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "root",
                Database = "new_student"
            }.ToString());
        }
    }
}