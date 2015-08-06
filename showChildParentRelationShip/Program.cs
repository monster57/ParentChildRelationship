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
            var parentChildMap = new ParentChildUtil().GetParentToChildrenMap();
            var relationMapper = new RelationMapper(ParentNodeList.GetParentNodeList(ParentNodeList.CreateNodeListFrom(parentChildMap) , parentChildMap));
//            RunWithTimeCheck(() => { Printer.Print(); });
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