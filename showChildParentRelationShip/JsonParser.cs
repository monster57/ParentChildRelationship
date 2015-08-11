using System;
using System.Collections.Generic;
using System.Linq;

namespace ParentChildRelationship
{
    public class JsonParser
    {
        private readonly List<Anchor> _anchorList;
        private readonly IDictionary<string, IEnumerable<Fact>> _parentChildMap;
        
        public JsonParser(List<Anchor> anchorList)
        {
            _anchorList = anchorList;
            _parentChildMap = new ParentChildUtil().GetParentToChildrenMap();
        }

        public string GetParentFactSet()
        {
            var anchorList = _anchorList.Select(anchor => new Fact {FactId = anchor.Data}).ToList();
            return anchorList.ToJson();
        }

        public string GetParentChildSet()
        {
            return _parentChildMap.ToJson();
        }
    }
}