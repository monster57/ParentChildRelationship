using System.Collections.Generic;

namespace ParentChildRelationship.Console
{
    internal class Printer
    {
        public static void Print(List<string> parentToChildrenMap)
        {
            foreach (var list in parentToChildrenMap)
            {
                PrintFact(list);
            }   
        }

        private static void PrintFact(string relationString)
        {
            Logger.Log("{0} ", relationString);
        }
    }
}