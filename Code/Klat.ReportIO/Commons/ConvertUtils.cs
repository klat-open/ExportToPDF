using iTextSharp.text.pdf;
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
                    return PdfPCell.ALIGN_LEFT;
                case HorizontalAlignment.Center:
                    return PdfPCell.ALIGN_CENTER;
                case HorizontalAlignment.Right:
                    return PdfPCell.ALIGN_RIGHT;
                default:
                    return PdfPCell.ALIGN_LEFT;
            }
        }

        public static int ToITextSharpValue(this VerticalAlignment valign)
        {
            switch (valign)
            {
                case VerticalAlignment.Top:
                    return PdfPCell.ALIGN_TOP;
                case VerticalAlignment.Middle:
                    return PdfPCell.ALIGN_MIDDLE;
                case VerticalAlignment.Bottom:
                    return PdfPCell.ALIGN_BOTTOM;
                default:
                    return PdfPCell.ALIGN_TOP;
            }
        }
    }
}
