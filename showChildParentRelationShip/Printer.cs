using System.Collections.Generic;

namespace ParentChildRelationship
{
    internal class Printer
    {
        public static void Print(List<List<string>> parentToChildrenMap)
        {
            foreach (var list in parentToChildrenMap)
            {
                PrintFact(string.Join("==>", list));
            }
        }

        private static void PrintFact(string relationString)
        {
            Logger.Log("{0} ", relationString);
        }
    }
}