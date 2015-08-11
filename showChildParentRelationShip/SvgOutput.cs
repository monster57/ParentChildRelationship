using System.Collections.Generic;
using System.Linq;

namespace ParentChildRelationship
{

    public class SvgOutput
    {
        private readonly List<Anchor> _anchors;
        private static int _positionY = ConfigSettings.MinYPosition;
        private static readonly List<Anchor> UsedParent = new List<Anchor>();

        public SvgOutput(List<Anchor> anchors)
        {
            _anchors = anchors;
        }

        public string GetSvg()
        {
            const string header = "<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">\n";
            const string footer = "</svg>";
            var lines = new List<Line>();
            var texts = new List<Text>();
            CreateSvgComponentsList(lines, texts);
            var lineSvg = GetLineSvg(lines);
            var textSvg = GetTextSvg(texts);
            return header + textSvg + lineSvg + footer;
        }

        private static string GetTextSvg(IEnumerable<Text> texts)
        {
            return texts.Aggregate("",
                (current, text) =>
                    current +
                    ("<text x=\"" + text.PositionX + "\" y=\"" + text.PositionY +
                     "\" font-family=\"Verdana\" font-size=\"10\">" + text.Content + "</text>\n"));
        }

        private static string GetLineSvg(IEnumerable<Line> lines)
        {
            return lines.Aggregate("",
                (current, line) => current +
                                   ("<line x1=\"" + line.PositionX + "\" y1=\"" + line.PositionY + "\" x2=\"" +
                                    line.PositionX1 + "\" y2=\"" + line.PositionY1 +
                                    "\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n"));
        }

        private void CreateSvgComponentsList(ICollection<Line> lines, ICollection<Text> texts)
        {
            var startingXPosition = 0;
            foreach (var anchor in _anchors)
            {
                var startingYPosition = _positionY;
                var usedAnchor = new List<Anchor> {anchor};
                texts.Add(new Text {Content = anchor.Data, PositionX = startingXPosition, PositionY = startingYPosition});
                AddSvgComponent(lines, texts, startingXPosition, startingYPosition, anchor, usedAnchor);
                if (_positionY <= ConfigSettings.MaxYPosition) continue;
                _positionY = ConfigSettings.MinYPosition;
                startingXPosition += ConfigSettings.StartFromNewXPosition;
            }
        }

        private static void AddSvgComponent(ICollection<Line> lines, ICollection<Text> texts, int startingXPosition,
            int startingYPosition, Anchor anchor, ICollection<Anchor> usedAnchor)
        {
            var oldStartingXPosition = startingXPosition;
            var oldStartingYPosition = startingYPosition;
            startingXPosition += ConfigSettings.IncreamentedXPosition;
            if (anchor.Children == null || anchor.Children.Count == ConfigSettings.NotAcceptableValue)
            {
                startingXPosition -= ConfigSettings.IncreamentedXPosition;
                return;
            }
            if (!UsedParent.Contains(anchor))
            {
                lines.Add(new Line
                {
                    PositionX = oldStartingXPosition + 20,
                    PositionY = startingYPosition - 5,
                    PositionX1 = startingXPosition - 20,
                    PositionY1 = startingYPosition - 5
                });
            }
            UsedParent.Add(anchor);
            
            
            
            foreach (var child in anchor.Children.Where(child => !usedAnchor.Contains(child)))
            {
                texts.Add(new Text {Content = child.Data, PositionX = startingXPosition, PositionY = startingYPosition});
                usedAnchor.Add(child);
                
                lines.Add(new Line
                {
                    PositionX = oldStartingXPosition + 30,
                    PositionY = startingYPosition - 5,
                    PositionX1 = startingXPosition,
                    PositionY1 = startingYPosition - 5
                });

                lines.Add(new Line
                {
                    PositionX = oldStartingXPosition + 30,
                    PositionY = oldStartingYPosition - 5,
                    PositionX1 = oldStartingXPosition + 30,
                    PositionY1 = startingYPosition-5
                });
                AddSvgComponent(lines, texts, startingXPosition, startingYPosition, child, usedAnchor );
                UsedParent.Add(child);
                startingYPosition += ConfigSettings.IncreamentedYPosition;
                _positionY += ConfigSettings.IncreamentedYPosition;
            }
        }
    }
}