using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ParentChildRelationship.ConsolePrint
{
    internal class Printer
    {
        
        public static void PrintWithTimeCheck(List<string> displayList)
        {
            var sw = new Stopwatch();
            sw.Start();
            Print(displayList);
            sw.Stop();
            Console.WriteLine("Took {0} milliseconds :)", sw.ElapsedMilliseconds);
        }

        private static void Print(List<string> parentToChildrenMap)
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