using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ParentChildRelationship
{
    public class ConnectionPool
    {
        private static ConcurrentBag<SqlConnectionWrapper> _sqlConnectionWrappers;
        private static readonly object LockObject = new object();

        public static void Initialize(int numberOfConnections)
        {
            _sqlConnectionWrappers = new ConcurrentBag<SqlConnectionWrapper>();
            for (var i = 1; i <= numberOfConnections; i++)
            {
                _sqlConnectionWrappers.Add(new SqlConnectionWrapper(ConfigSettings.ConnectionString, i));
            }
        }

        public static int GetNumberOfConnections()
        {
            return _sqlConnectionWrappers.Count;
        }

        public static SqlConnectionWrapper GetAvailableConnection()
        {
            while (true)
            {
                lock (LockObject)
                {
                    if (!_sqlConnectionWrappers.Any(l => l.IsAvailable)) continue;
                    var con = _sqlConnectionWrappers.First(item => item.IsAvailable);
                    con.IsAvailable = false;
                    return con;
                }
            }
        }

        public static void ReturnConnection(SqlConnectionWrapper con)
        {
            con.IsAvailable = true;

        }
    }
}