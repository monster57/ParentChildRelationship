using System;
using System.Collections.Generic;
using System.Linq;

namespace ParentChildRelationship
{
    internal class Printer
    {
        public static void Print(IDictionary<string, IEnumerable<Fact>> parentToChildrenMap)
        {
            foreach (var parentChildIdPair in parentToChildrenMap)
            {
                parentChildIdPair.Value.ToList().ForEach(fact => { PrintFact(parentChildIdPair.Key, fact); });
            }
        }

        private static void PrintFact(string parentFactId, Fact fact)
        {
            Console.WriteLine("{0} ==> {1}", parentFactId, fact.FactId);
        }
    }
}