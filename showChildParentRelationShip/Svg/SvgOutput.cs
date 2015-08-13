using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParentChildRelationship.Svg
{
    public class SvgOutput
    {
        private  int _positionY = ConfigSettings.MinYPosition;
        private readonly List<Anchor> _usedParent = new List<Anchor>();
        private readonly List<Anchor> _anchors;

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

        private string GetTextSvg(IEnumerable<Text> texts)
        {
            var textOutput = new StringBuilder();
            foreach (var text in texts)
            {
                textOutput.Append(CreateSvgText(text.PositionX, text.PositionY, text.Content));
            }
            return textOutput.ToString();
        }

        private string GetLineSvg(IEnumerable<Line> lines)
        {
            var lineOutput = new StringBuilder();
            foreach (var line in lines)
            {
                lineOutput.Append(CreateSvgLine(line.PositionX, line.PositionY, line.PositionX1, line.PositionY1));
            }
            return lineOutput.ToString();
        }

        private string CreateSvgText(int positionX, int positionY, string content)
        {
            var svgTextBulder = new StringBuilder();
            svgTextBulder.Append("<text x=\"");
            svgTextBulder.Append(positionX);
            svgTextBulder.Append("\" y=\"");
            svgTextBulder.Append(positionY);
            svgTextBulder.Append("\" font-family=\"Verdana\" font-size=\"10\">");
            svgTextBulder.Append(content);
            svgTextBulder.Append("</text>\n");

            return svgTextBulder.ToString();
        }

        private string CreateSvgLine(int positionX, int positionY, int positionX1, int positionY1)
        {
            var svgLineBuilder = new StringBuilder();
            svgLineBuilder.Append("<line x1=\"");
            svgLineBuilder.Append(positionX);
            svgLineBuilder.Append("\" y1=\"");
            svgLineBuilder.Append(positionY);
            svgLineBuilder.Append("\" x2=\"");
            svgLineBuilder.Append(positionX1);
            svgLineBuilder.Append("\" y2=\"");
            svgLineBuilder.Append(positionY1);
            svgLineBuilder.Append("\" style=\"stroke:rgb(255,0,0);stroke-width:2\"/>\n");
            return svgLineBuilder.ToString();
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

        private void AddSvgComponent(ICollection<Line> lines, ICollection<Text> texts, int startingXPosition,
            int startingYPosition, Anchor anchor, ICollection<Anchor> usedAnchor)
        {
            var oldPositionX = startingXPosition;
            var oldPositionY = startingYPosition;
            startingXPosition += ConfigSettings.IncreamentedXPosition;
            if (anchor.Children == null || anchor.Children.Count == ConfigSettings.NotAcceptableValue) return;
            if (!_usedParent.Contains(anchor))
                AddLineForIndependentParent(lines, oldPositionX, startingXPosition, startingYPosition);
            _usedParent.Add(anchor);
            foreach (var child in anchor.Children.Where(child => !usedAnchor.Contains(child)))
            {
                texts.Add(new Text {Content = child.Data, PositionX = startingXPosition, PositionY = startingYPosition});
                usedAnchor.Add(child);
                AddChildParentConnectorLine(lines, oldPositionX, startingXPosition, startingYPosition);
                AddVerticalLine(lines, oldPositionX, oldPositionY, startingYPosition);
                AddSvgComponent(lines, texts, startingXPosition, startingYPosition, child, usedAnchor);
                _usedParent.Add(child);
                startingYPosition += ConfigSettings.IncreamentedYPosition;
                _positionY += ConfigSettings.IncreamentedYPosition;
            }
        }

        private void AddLineForIndependentParent(ICollection<Line> lines, int oldPositionX,
            int startingXPosition, int startingYPosition)
        {
            var positionX = oldPositionX + 20;
            var positionY = startingYPosition - 5;
            var positionX1 = startingXPosition - 20;
            var positionY1 = startingYPosition - 5;
            AddLine(lines, positionX, positionY, positionX1, positionY1);
        }

        private void AddVerticalLine(ICollection<Line> lines, int oldPositionX, int oldPositionY,
            int startingYPosition)
        {
            var positionX = oldPositionX + 30;
            var positionY = oldPositionY - 5;
            var positionX1 = oldPositionX + 30;
            var positionY1 = startingYPosition - 5;
            AddLine(lines, positionX, positionY, positionX1, positionY1);
        }

        private void AddChildParentConnectorLine(ICollection<Line> lines, int oldPositionX,
            int startingXPosition, int startingYPosition)
        {
            var positionX = oldPositionX + 30;
            var positionY = startingYPosition - 5;
            var positionX1 = startingXPosition;
            var positionY1 = startingYPosition - 5;
            AddLine(lines, positionX, positionY, positionX1, positionY1);
        }

        private void AddLine(ICollection<Line> lines, int xPosition, int yPosition, int x1Position,
            int y1Position)
        {
            lines.Add(new Line
            {
                PositionX = xPosition,
                PositionY = yPosition,
                PositionX1 = x1Position,
                PositionY1 = y1Position
            });
        }
    }
}