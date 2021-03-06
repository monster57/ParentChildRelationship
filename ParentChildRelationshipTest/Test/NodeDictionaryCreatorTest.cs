﻿using System;
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
        public void ShouldGetAListOfNode()
        {
            var expected = new List<Node> {new Node {NodeData = "1"}};
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].NodeData, ParentNodeList.CreateNodeListFrom(_stringListDictionary)[i].NodeData);
            }
        }
        
        [Test]
        public void AddNodeListToListElement()
        {
            var expected = new List<Node>();
            var list = new List<Node> {new Node {NodeData = "2"}, new Node {NodeData = "3"}};
            var node = new Node{NodeData = "1", NodeList = list};
            expected.Add(node);
            var actual = ParentNodeList.GetParentNodeList(ParentNodeList.CreateNodeListFrom(_stringListDictionary) , _stringListDictionary);
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].NodeData, actual[i].NodeData);
                for (var j = 0; j < expected[i].NodeList.Count; j++)
                {
                    Assert.AreEqual(expected[i].NodeList[j].NodeData, actual[i].NodeList[j].NodeData);
                }
            }
        }


    }
}
