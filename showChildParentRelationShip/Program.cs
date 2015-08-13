using System;
using System.Diagnostics;
using ParentChildRelationship.ConsolePrint;
using ParentChildRelationship.Svg;

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
            var svgString = new SvgOutput(parentList).GetSvg();
            var displayList = DisplayFigure.GetParentChildRepresentation(parentList);
            var option = Console.ReadLine();
            var output = new OutputOption(displayList , svgString);
            output.ShowOutput(option);
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