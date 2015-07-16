using System;
using System.Text;

namespace showChildParentRelationShip
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var stringBuilder = new StringBuilder();
            var dataHolder = new DataHolder();
            var dimensions = dataHolder.GetAllParentdata();
            var map = dataHolder.GetAllParentsIdMappedWithDimensions(dimensions);
            var childDataMappedWithParentId = dataHolder.GetAllChildsDataMappedWithParentId(map);
            var allChildId = dataHolder.GetAllChildIdMappedWithParentId(childDataMappedWithParentId);

            foreach (var data in allChildId)
            {
                foreach (var dimension in data.Value)
                {
                    stringBuilder.Append(data.Key);
                    stringBuilder.Append(" ==> ");
                    stringBuilder.Append(dimension.FactId);
                    stringBuilder.Append("\n");
                    
                }
            }
            Console.WriteLine(stringBuilder);
            Console.ReadKey();
        }
    }
}
