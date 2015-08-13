using System;
using ParentChildRelationship.ConsolePrint;
using ParentChildRelationship.Svg;

namespace ParentChildRelationship
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run(args);
            Console.ReadKey();
        }

        private static void Run(string[] args)
        {
            
            var parentChildMap = new ParentChildUtil().GetParentToChildrenMap();
            var parentList = ParentList.GetParentSet(parentChildMap);
            var svgString = new SvgOutput(parentList).GetSvg();
            var displayList = new DisplayFigure().GetParentChildRepresentation(parentList);
            var output = new OutputOption(displayList, svgString);
            var option = args[0];
            output.ShowOutput(option);
        }
    }
}