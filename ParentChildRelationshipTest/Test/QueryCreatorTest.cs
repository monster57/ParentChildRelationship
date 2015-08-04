using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    internal class QueryCreatorTest
    {
        [Test]
        public void ShouldGiveAQueryToGetAllTheParentChildIdFromFactDimension()
        {
            const string query = "select distinct fact.id " +
                  "from fact_dimension_relationship.fact_data fact " +
                  "join fact_dimension_relationship.parent_child_data child " +
                  "on ( fact.WhatKey = child.childWhatKey or child.childWhatKey = '*') " +
                  "and ( fact.Where4Key = child.childWhere4Key or child.childWhere4Key = '*') " +
                  "and ( fact.How3Key = child.childHow3Key or child.childHow3Key = '*' ) " +
                  "and fact.When3Key = child.When3Key " +
                  "and child.anchorwhatKey = 12"+
                  " and child.anchorwhere4Key = 1" +
                  " and child.anchorhow3Key = 2" +
                  " and child.when3Key = 8;"; 
            var factDimension = new FactDimensions
            {
                Howkey = "2",
                Whatkey = "12",
                Whenkey = "8",
                Wherekey = "1"
            };
            Assert.AreEqual(query, QueryCreator.GetChildIdQuery(factDimension));
        }

        [Test]
        public void ShouldGiveAQueryToGetAllTheParentIdWithDimensions()
        {
            const string query = "select distinct fact.id , fact.When3Key , fact.How3Key , fact.WhatKey , fact.Where4Key" +
                               " from fact_dimension_relationship.fact_data fact " +
                               "join fact_dimension_relationship.parent_child_data child " +
                               "on fact.WhatKey = child.anchorWhatKey " +
                               "and fact.Where4Key = child.anchorWhere4Key " +
                               "and fact.How3Key = child.anchorHow3Key " +
                               "and fact.When3Key  = child.When3Key;";

            Assert.AreEqual(query, QueryCreator.GetParentIdQuery());
        }
    }
}