using System.Collections.Generic;
using System.Text;

namespace ParentChildRelationship
{
    public static class DisplayFigure
    {
        public static List<string> GetParentChildRepresentation(List<Anchor> parentList)
        {
            var display = new List<string>();
            foreach (var anchor in parentList)
            {
                var stringBuilder = new StringBuilder();
                AddDataToList(anchor, new List<string>(), stringBuilder);
                if (stringBuilder.ToString().Length > 4) display.Add(stringBuilder.ToString());
            }
            return display;
        }

        private static void AddDataToList(Anchor anchor, ICollection<string> rowList, StringBuilder tree)
        {
            rowList.Add(anchor.Data);
            tree.Append(anchor.Data.PadRight(3, ' '));
            if (anchor.Children == null)
            {
                AddLine(rowList, tree);
                return;
            }
            foreach (var child in anchor.Children)
            {
                if (rowList.Contains(child.Data)) return;
                tree.Append(" " + (char) 26 + " ");
                AddDataToList(child, rowList, tree);
                rowList.Remove(child.Data);
            }
        }

        private static void AddLine(ICollection<string> rowList, StringBuilder tree)
        {
            tree.Append("\n");
            for (var i = 0; i < rowList.Count - 1; i++)
            {
                tree.Append("   ");
                if (i > 0) tree.Append("   ");
            }
        }
    }
}