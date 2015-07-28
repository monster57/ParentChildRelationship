using System;
using System.Configuration;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    internal class ConnectionPoolTest
    {
        [SetUp]
        public void Init()
        {
            _numberOfConnections = Convert.ToInt32(ConfigurationManager.AppSettings["degreeOfParallelism"]);
            ConnectionPool.Initialize(_numberOfConnections);
        }

        private int _numberOfConnections;

        [Test]
        public void GetMeOneConnection()
        {
            var con = ConnectionPool.GetAvailableConnection();
            ConnectionPool.ReturnConnection(con);
            var con1 = ConnectionPool.GetAvailableConnection();
            Assert.AreEqual(con, con1);
        }

        [Test]
        public void ShouldCreateConnectionsFromConfigSetting()
        {
            var connections = ConnectionPool.GetNumberOfConnections();
            Assert.AreEqual(connections, _numberOfConnections);
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void ShouldGiveExceptionWhenConnectionUnavailable()
        {
            for (var i = 0; i < 5; i++)
            {
                ConnectionPool.GetAvailableConnection();
            }
        }

        [Test]
        public void ShouldWaitToGetAConnectionIfConnectionIsNotAvailable()
        {
            
        }
    }
}