using System.Collections.Generic;
using System.Text;

namespace ParentChildRelationship
{
    public static class DisplayFigure
    {
        public static List<string> GetParentChildRepresentation(List<Anchor> parentList)
        {
            var displayList = new List<List<string>>();
            var display = new List<string>();

            foreach (var anchor in parentList)
            {
                var stringBuilder = new StringBuilder();
                AddDataToList(anchor, new List<string>(), displayList, stringBuilder);
                if (stringBuilder.ToString().Length> 4)
                {
                    display.Add(stringBuilder.ToString());
                };
            }
            return display;
        }

        private static void AddDataToList(Anchor anchor, ICollection<string> rowList,
            ICollection<List<string>> displayList, StringBuilder tree)
        {
            rowList.Add(anchor.Data);
            AddElement(anchor, tree);
            if (anchor.Children == null)
            {
                displayList.Add(new List<string>(rowList));
                tree.Append("\n");
                for (var i = 0; i < rowList.Count - 1; i++)
                {
                    tree.Append("   ");
                    if (i> 0) tree.Append("   ");
                }
                return;
            }
            foreach (var child in anchor.Children)
            {
                if (rowList.Contains(child.Data))
                {
                    displayList.Add(new List<string>(rowList));
                    return;
                }
                tree.Append(" " + (char) 26 + " ");
                AddDataToList(child, rowList, displayList, tree);
                rowList.Remove(child.Data);
            }
        }

        private static void AddElement(Anchor anchor, StringBuilder tree)
        {
            switch (anchor.Data.Length)
            {
                case 3:
                    tree.Append(anchor.Data);
                    break;
                case 2:
                    tree.Append(anchor.Data + " ");
                    break;
                default:
                    tree.Append(anchor.Data + "  ");
                    break;
            }
        }
    }
}