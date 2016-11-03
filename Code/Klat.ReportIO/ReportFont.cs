using iTextSharp.text;
using iTextSharp.text.pdf;
using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;

namespace Klat.ReportIO
{
    public class ReportFont
    {
        private ReportFont() { }

        public FontList FontList { get; set; }

        public ReportColor Color { get; set; }

        public int FontSize { get; set; }

        public FontStyle Style { get; set; }

        public static ReportFont Create()
        {
            return new ReportFont();
        }

        public static ReportFont Create(FontList fontList, int fontSize, ReportColor color, FontStyle style)
        {
            return new ReportFont
            {
                FontList = fontList,
                Color = color,
                FontSize = fontSize,
                Style = style
            };
        }

        public static implicit operator Font(ReportFont color)
        {
            string fontPath = FontUtils.GetFontPath(color.FontList, color.Style);
            //BaseFont bF = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            BaseFont bF = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(bF, color.FontSize, Font.NORMAL, color.Color);

            return font;
        }
    }
}
