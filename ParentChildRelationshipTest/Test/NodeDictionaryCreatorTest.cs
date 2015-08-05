using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ParentChildRelationship;

namespace ParentChildRelationshipTest.Test
{
    [TestFixture]
    class NodeDictionaryCreatorTest
    {
        [SetUp]
        public void Init()
        {
            _stringListDictionary = new Dictionary<string , List<string>>();
            var stringList = new List<string> {"2", "3"};
            _stringListDictionary.Add("1" , stringList);
        }

        private static Dictionary<string, List<string>> _stringListDictionary;
        [Test]
        public void ShouldGetADictionaryWhoseIdNodeType()
        {
            var dictionary = new Dictionary<Node , List<string>>();
            var  list= new List<string>{"2" ,"3" };
            dictionary.Add(new Node{NodeData = "1" } , list);
        }
    }
}
