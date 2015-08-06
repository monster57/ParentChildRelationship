using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentChildRelationship
{
    public static class DisplayFigure
    {
        public static List<List<string>> GetParentChildRepresentation(List<Anchor> parentList)
        {
            var displayList = new List<List<string>>();

            foreach (var anchor in parentList)
            {
                AddDataToList(anchor, new List<string>(), displayList);
            }
            return displayList;
        }

        private static void AddDataToList(Anchor anchor, ICollection<string> rowList, ICollection<List<string>> displayList)
        {
            rowList.Add(anchor.Data);
            if (anchor.Children == null)
            {
                displayList.Add(new List<string>(rowList));
                return;
            }
            foreach (var child in anchor.Children)
            {
                if (rowList.Contains(child.Data))
                {
                    displayList.Add(new List<string>(rowList));
                    return;
                }
                AddDataToList(child , rowList , displayList);
                rowList.Remove(child.Data);
            }
        }
    }
}
