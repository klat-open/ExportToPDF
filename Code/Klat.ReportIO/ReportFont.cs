using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;

namespace Klat.ReportIO
{
    public class ReportFont
    {
        private ReportFont() { }

        public FontList FontList { get; set; }

        public ReportColor Color { get; set; }

        public float FontSize { get; set; }

        public FontStyle Style { get; set; }

        public static implicit operator iTextSharp.text.Font(ReportFont color)
        {
            string fontPath = FontUtils.GetFontPath(color.FontList, color.Style);
            //BaseFont bF = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.pdf.BaseFont bF = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bF, color.FontSize, iTextSharp.text.Font.NORMAL, color.Color);

            return font;
        }

        public static ReportFont Create()
        {
            return new ReportFont();
        }

        public static ReportFont Create(FontList fontList, float fontSize, ReportColor color, FontStyle style)
        {
            return new ReportFont
            {
                FontList = fontList,
                Color = color,
                FontSize = fontSize,
                Style = style
            };
        }
    }
}
