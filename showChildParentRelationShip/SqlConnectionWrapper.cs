using MySql.Data.MySqlClient;

namespace ParentChildRelationship
{
    public class SqlConnectionWrapper
    {
        public MySqlConnection SqlConnection { get; private set; }

        public SqlConnectionWrapper(string connectionString,int id)
        {
            Id = id;
            SqlConnection = new MySqlConnection(connectionString);
            IsAvailable = true;
        }

        public int Id { get; private set; }

        public bool IsAvailable { get; set; }
    }
}