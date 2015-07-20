using System.ComponentModel;
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
                                 " Anchor.When3Key , Anchor.AnchorHow3Key , Anchor.AnchorWhatKey , Anchor.AnchorWhere4Key" +
                                 " from new_student.fact_data_sheet1 fact join" +
                                 " (select Distinct When3Key , AnchorHow3Key , AnchorWhere4Key , AnchorWhatKey from new_student.parentchild_sheet1) Anchor" +
                                 " on fact.WhatKey = Anchor.AnchorWhatKey" +
                                 " and fact.How3Key = Anchor.AnchorHow3Key" +
                                 " and fact.When3Key = Anchor.When3Key" +
                                 " and fact.Where4Key = Anchor.AnchorWhere4Key;";
        
            Assert.AreEqual(query , QueryCreator.GetParentIdQuery());
        }

        [Test]
        public void ShouldGiveAQueryToGetAllTheParentChildIdFromFactDimension()
        {
            const string query = "select fact.Fact_DataId from new_student.fact_data_sheet1 fact " +
                                 "join (SELECT When3Key , ChildHow3Key , ChildWhere4Key , ChildWhatKey from " +
                                 "new_student.parentchild_sheet1 where AnchorWhatKey= 12 and AnchorWhere4Key = 1 " +
                                 "and AnchorHow3Key = 2 and When3Key = 8) Child" +
                                 " on fact.WhatKey = Child.ChildWhatKey and fact.How3Key = Child.ChildHow3Key " +
                                 "and fact.When3Key = Child.When3Key and fact.Where4Key = Child.ChildWhere4Key;";
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
