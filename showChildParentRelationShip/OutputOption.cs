using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ParentChildRelationship.ConsolePrint;

namespace ParentChildRelationship
{
    public class OutputOption
    {
        private readonly List<string> _displayList;
        private readonly string _svgString;

        public OutputOption(List<string> displayList, string svgString)
        {
            _displayList = displayList;
            _svgString = svgString;
        }

        public void ShowOutput(string option)
        {
            switch (option.ToLower())
            {
                case "g":
                    File.WriteAllText(@"D:\something.svg", _svgString , Encoding.UTF8);
                    Console.WriteLine("Output is saved to file");
                    break;
                case "c":
                    new Printer().PrintWithTimeCheck(_displayList);
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}