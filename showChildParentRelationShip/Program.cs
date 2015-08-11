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
//            var parentChildMap = new ParentChildUtil().GetParentToChildrenMap();
//            var parentList = ParentList.GetParentSet(parentChildMap);
//            var displayList = DisplayFigure.GetParentChildRepresentation(parentList);
//            var jsonParser = new JsonParser(parentList);
//            File.WriteAllText(
//                @"D:\PracticeVisualStudio\Data\ParentFact.json",
//                jsonParser.GetParentFactSet());
//            File.WriteAllText(
//                @"D:\PracticeVisualStudio\Data\ParentChildData.json",
//                jsonParser.GetParentChildSet());
//            Console.WriteLine(jsonParser.GetParentFactSet());

//            RunWithTimeCheck(() => { Printer.Print(displayList); });
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