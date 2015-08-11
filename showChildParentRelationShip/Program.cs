using System;
using System.Diagnostics;
using System.IO;

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
            var parentList = ParentList.GetParentSet(parentChildMap);
            var svgString = new SvgOutput(parentList).GetSvg() ;
//            var displayList = DisplayFigure.GetParentChildRepresentation(parentList);
//            var jsonParser = new JsonParser(parentList);

//            RunWithTimeCheck(() => { Printer.Print(displayList); });

           File.WriteAllText(@"D:\PracticeVisualStudio\svg\something.svg", svgString);
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