using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ParentChildRelationship
{
    public class SqlConnectionWrapper
    {
        private readonly object _lockSystem = new object();
        private readonly MySqlConnection _sqlConnection;

        public SqlConnectionWrapper(string connectionString, int id)
        {
            Id = id;
            _sqlConnection = new MySqlConnection(connectionString);
            IsAvailable = true;
        }

        public int Id { get; private set; }
        public bool IsAvailable { get; set; }

        public bool Execute(Func<MySqlConnection, DataTable> executeAction)
        {
            try
            {
                lock (_lockSystem)
                {
                    executeAction.Invoke(_sqlConnection);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}