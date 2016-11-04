using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Commons
{
    public static class ConvertUtils
    {
        public static int ToITextSharpValue(this HorizontalAlignment align)
        {
            switch (align)
            {
                case HorizontalAlignment.Left:
                    return iTextSharp.text.pdf.PdfPCell.ALIGN_LEFT;
                case HorizontalAlignment.Center:
                    return iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER;
                case HorizontalAlignment.Right:
                    return iTextSharp.text.pdf.PdfPCell.ALIGN_RIGHT;
                default:
                    return iTextSharp.text.pdf.PdfPCell.ALIGN_LEFT;
            }
        }

        public static int ToITextSharpValue(this VerticalAlignment valign)
        {
            switch (valign)
            {
                case VerticalAlignment.Top:
                    return iTextSharp.text.pdf.PdfPCell.ALIGN_TOP;
                case VerticalAlignment.Middle:
                    return iTextSharp.text.pdf.PdfPCell.ALIGN_MIDDLE;
                case VerticalAlignment.Bottom:
                    return iTextSharp.text.pdf.PdfPCell.ALIGN_BOTTOM;
                default:
                    return iTextSharp.text.pdf.PdfPCell.ALIGN_TOP;
            }
        }

        public static int ToITextSharpValue(this TextAlignment alignment)
        {
            switch (alignment)
            {
                case TextAlignment.Left:
                    return iTextSharp.text.Element.ALIGN_LEFT;
                case TextAlignment.Center:
                    return iTextSharp.text.Element.ALIGN_CENTER;
                case TextAlignment.Right:
                    return iTextSharp.text.Element.ALIGN_RIGHT;
                case TextAlignment.Justified:
                    return iTextSharp.text.Element.ALIGN_JUSTIFIED_ALL;
                default:
                    return iTextSharp.text.Element.ALIGN_LEFT;
            }
        }
    }
}
