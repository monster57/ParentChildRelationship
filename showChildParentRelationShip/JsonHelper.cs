using System.Web.Script.Serialization;

namespace ParentChildRelationship
{
    public static class JsonHelper
    {
        public static string ToJson(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        
    }
}