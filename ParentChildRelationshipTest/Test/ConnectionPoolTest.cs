﻿using System;
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
        public void ShouldCreateConnectionsFromConfigSetting()
        {
            var connections = ConnectionPool.GetNumberOfConnections();
            Assert.AreEqual(connections, _numberOfConnections);
        }
    }
}