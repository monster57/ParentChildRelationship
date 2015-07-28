using System;
using System.Diagnostics;

namespace ParentChildRelationship
{
    public static class Logger
    {
        public static void Log(string message, params object[] list)
        {
            Debug.WriteLine(message, list);
            Console.WriteLine(message, list);
        }
    }
}