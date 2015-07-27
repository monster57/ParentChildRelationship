using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MySql.Data.MySqlClient;

namespace ParentChildRelationship
{
    public class ConnectionPool
    {
        
        private static List<SqlConnectionWrapper> _sqlConnectionWrappers;
        public static void Initialize(int numberOfConnections)
        {
            _sqlConnectionWrappers = new List<SqlConnectionWrapper>();
            for (var i = 1; i <= numberOfConnections; i++)
            {
                _sqlConnectionWrappers.Add(new SqlConnectionWrapper(ConfigSettings.ConnectionString, i));
            }
        }
        public static int GetNumberOfConnections()
        {
            return _sqlConnectionWrappers.Count;
        }

        public static SqlConnectionWrapper GiveMeConnection()
        {
            var con = _sqlConnectionWrappers.First(item => item.IsAvailable);
            con.IsAvailable = false;
            return con;
        }

        public static void ReturnConnection(SqlConnectionWrapper con)
        {
            con.IsAvailable = true;
        }
    }
}