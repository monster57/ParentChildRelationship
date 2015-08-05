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
            var ParentChildMap = new ParentChildUtil().GetParentToChildrenMap();
            var relationMapper = new RelationMapper(ParentNodeList.GetParentNodeList(ParentNodeList.CreateNodeListFrom(ParentChildMap) , ParentChildMap));
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