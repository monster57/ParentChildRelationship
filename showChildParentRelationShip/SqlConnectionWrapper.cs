using MySql.Data.MySqlClient;

namespace ParentChildRelationship
{
    public class SqlConnectionWrapper
    {
        public object LockSystem = new object();

        public SqlConnectionWrapper(string connectionString, int id)
        {
            Id = id;
            SqlConnection = new MySqlConnection(connectionString);
            IsAvailable = true;
        }

        public MySqlConnection SqlConnection { get; private set; }
        public int Id { get; private set; }
        public bool IsAvailable { get; set; }
    }
}