using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Pdf
{
    public class Border
    {
        public Border()
        {
            Top = new BorderItem();
            Right = new BorderItem();
            Bottom = new BorderItem();
            Left = new BorderItem();
        }

        public BorderItem Top { get; set; }

        public BorderItem Right { get; set; }

        public BorderItem Bottom { get; set; }

        public BorderItem Left { get; set; }

        public BorderStyle Style { get; set; }

        public int? Width { get; set; }

        public ReportColor Color { get; set; }
    }
}
