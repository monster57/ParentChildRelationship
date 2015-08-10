﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace ParentChildRelationship
{
    public class JsonParser
    {
        private readonly List<Anchor> _anchorList;
        private IDictionary<string, IEnumerable<Fact>> _parentChildMap;
        
        public JsonParser(List<Anchor> anchorList)
        {
            _anchorList = anchorList;
            _parentChildMap = new ParentChildUtil().GetParentToChildrenMap();
        }

        public string GetParentFactSet()
        {
            var anchorList =_anchorList.Select(anchor => new Fact {FactId = anchor.Data}).ToList();
            return anchorList.ToJson();
        }


        public string GetParentChildSet()
        {
            return _parentChildMap.ToJson();
        }

    }


    public static class JsonHelper
    {
        public static string ToJson(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        
    }
}