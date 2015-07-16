using System;
using System.Diagnostics;

namespace ParentChildRelationShip
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
        }

        private static void Run()
        {

            var sw = new Stopwatch();
            sw.Start();
            var dataContainer = new DataContainer();
            var relationshipCreator = new RelationshipCreator();
            var mappedParentIdWithDimension = dataContainer.GetAllParentsIdMappedWithDimensions();
            var mappedParentIdWithChildId = dataContainer.GetAllChildIdMappedWithParentId(mappedParentIdWithDimension);
            var result = relationshipCreator.GetParentChildRelationship(mappedParentIdWithChildId);

            Console.WriteLine(result);
            sw.Stop();
            Console.WriteLine("Took " + sw.ElapsedMilliseconds);
        }
    }
}
