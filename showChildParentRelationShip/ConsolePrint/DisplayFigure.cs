using System.Collections.Generic;
using System.Text;

namespace ParentChildRelationship.ConsolePrint
{
    public static class DisplayFigure
    {
        public static List<string> GetParentChildRepresentation(List<Anchor> parentList)
        {
            var display = new List<string>();
            foreach (var anchor in parentList)
            {
                var treeBuilder = new StringBuilder();
                CreateAnchorChildTree(anchor, new List<string>(), treeBuilder);
                display.Add(treeBuilder.ToString());
            }
            return display;
        }

        private static void CreateAnchorChildTree(Anchor anchor, ICollection<string> rowList, StringBuilder tree)
        {
            rowList.Add(anchor.Data);
            tree.Append(anchor.Data.PadRight(ConfigSettings.KeySize, ' '));
            if (anchor.Children == null)
            {
                AddLine(rowList, tree);
                return;
            }
            foreach (var child in anchor.Children)
            {
                if (rowList.Contains(child.Data)) return;
                tree.Append(" " + ConfigSettings.Arrow+ " ");
                CreateAnchorChildTree(child, rowList, tree);
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