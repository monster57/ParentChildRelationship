using System.Configuration;

namespace ParentChildRelationship
{
    public static class ConfigSettings
    {
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
    }
}