using System;
using System.Configuration;

namespace ParentChildRelationship
{
    public static class ConfigSettings
    {
        public static int ConnectionCount {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["connectionCount"]); }
        }

        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["parentChildRelation"].ConnectionString;} 
        }

        public static int DegreeOfParallelism {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["degreeOfParallelism"]); } 
        }
        public static string How3Key
        {
            get { return ConfigurationManager.AppSettings["How3Key"]; }
        }
        public static string WhatKey
        {
            get { return ConfigurationManager.AppSettings["WhatKey"]; }
        }
        public static string Where4Key
        {
            get { return ConfigurationManager.AppSettings["Where4Key"]; }
        }
        public static string When3Key
        {
            get { return ConfigurationManager.AppSettings["When3Key"]; }
        }
        public static string Id
        {
            get { return ConfigurationManager.AppSettings["id"]; }
        }
        public static string Anchor
        {
            get { return ConfigurationManager.AppSettings["anchor"]; }
        }
        public static string Child
        {
            get { return ConfigurationManager.AppSettings["child"]; }
        }
        public static string AnchorHow3Key
        {
            get { return ConfigurationManager.AppSettings["anchorHow3Key"]; }
        }
        public static string AnchorWhatKey
        {
            get { return ConfigurationManager.AppSettings["anchorWhatKey"]; }
        }
        public static string AnchorWhere4Key
        {
            get { return ConfigurationManager.AppSettings["anchorWhere4Key"]; }
        }
        public static string Fact
        {
            get { return ConfigurationManager.AppSettings["fact"]; }
        }
        public static string FactDataTable
        {
            get { return ConfigurationManager.AppSettings["factDataTable"]; }
        }

        public static string Schema
        {
            get{return ConfigurationManager.AppSettings["schema"];}
        }
        public static string ParentChildTable
        {
            get { return ConfigurationManager.AppSettings["parentChildTable"]; }
        }
        public static string And
        {
            get { return ConfigurationManager.AppSettings["and"]; }
        }
        public static string Or
        {
            get { return ConfigurationManager.AppSettings["or"]; }
        }
        public static string On
        {
            get { return ConfigurationManager.AppSettings["on"]; }
        }
        public static string Join
        {
            get { return ConfigurationManager.AppSettings["join"]; }
        }
        public static string Select
        {
            get { return ConfigurationManager.AppSettings["select"]; }
        }
        public static string From
        {
            get { return ConfigurationManager.AppSettings["from"]; }
        }
        public static string Distinct
        {
            get { return ConfigurationManager.AppSettings["distinct"]; }
        }
        public static int MinimumAcceptedLength
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["minimumAcceptedLength"]); }
        }
        public static int MaxYPosition
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["maxYPosition"]); }
        }
        public static int MinYPosition
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["minYPosition"]); }
        }

        public static int IncreamentedXPosition
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["increamentedXPosition"]); }
        }
        public static int IncreamentedYPosition
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["increamentedYPosition"]); }
        }
        public static int StartFromNewXPosition
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["startFromNewXPosition"]); }
        }

        public static int NotAcceptableValue
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["notAcceptableValue"]); }
        }
        public static int KeySize
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["keySize"]); }
        }
        public static char Arrow
        {
            get { return (char) Convert.ToInt32(ConfigurationManager.AppSettings["arrow"]); }
        }
    }
}