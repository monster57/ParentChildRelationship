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
            const string query = "select fact.id from fact_dimension_relationship.fact_data fact " +
                               "join (select distinct tab.childWhatKey , tab.childHow3Key , child.childWhere4Key , tab.When3Key " +
                               "from fact_dimension_relationship.parent_child_data child join " +
                               "(select distinct tab.childWhatKey , child.childHow3Key , tab.childWhere4Key , tab.When3Key " +
                               "from fact_dimension_relationship.parent_child_data child join " +
                               "(select distinct child.childWhatKey , tab.childHow3Key , tab.childWhere4Key , tab.When3Key " +
                               "from fact_dimension_relationship.parent_child_data child join " +
                               "(select when3Key , childhow3Key , childwhere4Key , childwhatKey from " +
                               "fact_dimension_relationship.parent_child_data where anchorwhatKey = 12" +
                               " and anchorwhere4Key = 1" +
                               " and anchorhow3Key = 2" +
                               " and when3Key = 8" +
                               ") tab " +
                               "on child.childWhatkey = tab.childwhatkey " +
                               "or tab.childwhatkey = '*' " +
                               "where child.childwhatkey !='*') tab on child.childHow3Key = tab.childHow3Key " +
                               "or tab.childHow3Key = '*' " +
                               "where child.childHow3Key!='*') tab " +
                               "on child.childWhere4Key = tab.childWhere4Key " +
                               "or tab.childWhere4Key = '*' " +
                               "where child.childWhere4Key !='*') child " +
                               "on fact.whatKey = child.childwhatKey and fact.how3Key = child.childhow3Key " +
                               "and fact.when3Key = child.when3Key and fact.where4Key = child.childwhere4Key;";
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
            const string query = "select fact.id ," +
                                 " anchor.when3Key , anchor.anchorhow3Key , anchor.anchorwhatKey , anchor.anchorwhere4Key" +
                                 " from fact_dimension_relationship.fact_data fact join" +
                                 " (select Distinct when3Key , anchorhow3Key , anchorwhere4Key , anchorwhatKey from fact_dimension_relationship.parent_child_data)" +
                                 " anchor on fact.whatKey = anchor.anchorwhatKey" +
                                 " and fact.how3Key = anchor.anchorhow3Key" +
                                 " and fact.when3Key = anchor.when3Key" +
                                 " and fact.where4Key = anchor.anchorwhere4Key;";

            Assert.AreEqual(query, QueryCreator.GetParentIdQuery());
        }
    }
}