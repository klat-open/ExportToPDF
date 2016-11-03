using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Pdf
{
    public class BorderItem
    {
        public BorderItem()
        {

        }

        public BorderItem(int? width, BorderStyle style, ReportColor color)
        {
            Width = width;
            Style = style;
            Color = color;
        }

        public BorderItem(BorderItem border)
            : this(border.Width, border.Style, border.Color)
        {
        }

        public int? Width { get; set; }

        public BorderStyle Style { get; set; }

        public ReportColor Color { get; set; }
    }
}
