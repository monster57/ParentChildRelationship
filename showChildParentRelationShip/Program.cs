using System;
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
            var displayList = new DisplayFigure().GetParentChildRepresentation(parentList);
            var option = Console.ReadLine();
            var output = new OutputOption(displayList, svgString);
            output.ShowOutput(option);
        }
    }
}