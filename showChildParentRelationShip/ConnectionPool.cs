using System.Collections.Generic;
using System.Data;

namespace ParentChildRelationship
{
    public static class ConnectionPool
    {
        private static List<SqlConnectionWrapper> _sqlConnectionWrappers;
        private static volatile int _currentConnectionId;

        public static void Initialize(int numberOfConnections)
        {
            _sqlConnectionWrappers = new List<SqlConnectionWrapper>();
            for (var i = 1; i <= numberOfConnections; i++)
            {
                _sqlConnectionWrappers.Add(new SqlConnectionWrapper(ConfigSettings.ConnectionString, i));
            }
        }

        public static DataTable Execute(string query)
        {
            DataTable result = null;
            GetConnectionWrapper().Execute((sqlConnection => result = DatabaseUtils.ExecuteQuery(query, sqlConnection)));
            return result;
        }

        private static SqlConnectionWrapper GetConnectionWrapper()
        {
            try
            {
                if (_currentConnectionId > 3) _currentConnectionId = 1;
                return _sqlConnectionWrappers[_currentConnectionId];
            }
            finally
            {
                _currentConnectionId++;
            }
        }

        public static int GetNumberOfConnections()
        {
            return _sqlConnectionWrappers.Count;
        }
    }
}