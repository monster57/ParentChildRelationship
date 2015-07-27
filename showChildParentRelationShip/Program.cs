using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

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
            RunWithTimeCheck(() =>
            {
                Printer.Print(new ParentChildUtil().GetParentToChildrenMap());
            });

        }

        private static void RunWithTimeCheck(Action action)
        {
            var sw = new Stopwatch();
            sw.Start();
            action.Invoke();
            sw.Stop();
            Console.WriteLine("Took {0} milliseconds :)" + sw.ElapsedMilliseconds);
        }
    }
}