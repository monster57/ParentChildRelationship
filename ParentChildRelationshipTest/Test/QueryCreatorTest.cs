using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    class QueryCreatorTest
    {
        [Test]
        public void ShouldGiveAQueryToGetAllTheParentIdWithDimensions()
        {
            const string query = "select fact.Fact_DataId ," +
                                 "parent.When3Key ,parent.AnchorHow3Key ,  parent.AnchorWhatKey , parent.AnchorWhere4Key " +
                                 "from new_student.fact_data_sheet1 fact join " +
                                 "(select Distinct AnchorHow3Key , AnchorWhatKey , AnchorWhere4Key , When3Key from new_student.parentchild_sheet1)" +
                                 " parent " +
                                 "on fact.WhatKey = parent.AnchorWhatKey " +
                                 "and fact.How3Key = parent.AnchorHow3Key " +
                                 "and fact.When3Key = parent.When3Key " +
                                 "and parent.AnchorWhere4Key = parent.AnchorWhere4Key;";

            Assert.AreEqual(query , QueryCreator.GetParentIdQuery);
        }
        [Test]
        public void ShouldGiveAQueryToGetAllTheParentChildIdFromFactDimension()
        {
            const string query = "select fact.Fact_DataId from new_student.fact_data_sheet1 fact " +
                                 "join (SELECT ChildHow3Key , ChildWhatKey , ChildWhere4Key , When3Key FROM " +
                                 "new_student.parentchild_sheet1 where AnchorWhatKey= 12 and AnchorWhere4Key = 1 " +
                                 "and AnchorHow3Key = 2 and When3Key = 8) child" +
                                 " on fact.WhatKey = child.ChildWhatKey and fact.How3Key = child.ChildHow3Key " +
                                 "and fact.When3Key = child.When3Key and fact.Where4Key = child.ChildWhere4Key;";
            var factDimention = new FactDimensions
            {
                Howkey = "2",
                Whatkey = "12",
                Whenkey = "8",
                Wherekey = "1"
            };
            Assert.AreEqual(query , QueryCreator.GetChildIdQuery(factDimention));
        }
    }
}
