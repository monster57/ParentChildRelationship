using System;
using System.Diagnostics;

namespace ParentChildRelationship
{
    internal class Program
    {
        private static void Main()
        {
            Run();
            Console.ReadKey();
        }

        private static void Run()
        {
            RunWithTimeCheck(() => { Printer.Print(new ParentChildUtil().GetParentToChildrenMap()); });
        }

        private static void RunWithTimeCheck(Action action)
        {
            var sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            Console.WriteLine("Took {0} milliseconds :)", sw.ElapsedMilliseconds);
        }
    }
}