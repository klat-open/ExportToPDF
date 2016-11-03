using Klat.ReportIO.Enums;
using OfficeOpenXml.Style;

namespace Klat.ReportIO.Commons
{
    public static class AlignmentUtils
    {
        public static HorizontalAlignment? ToHorizontalAlignment(this ExcelHorizontalAlignment horizontalAlignment)
        {
            switch (horizontalAlignment)
            {
                case ExcelHorizontalAlignment.Left:
                    return HorizontalAlignment.Left;
                case ExcelHorizontalAlignment.Center:
                    return HorizontalAlignment.Center;
                case ExcelHorizontalAlignment.Right:
                    return HorizontalAlignment.Right;
                default:
                    return null;
            }
        }

        public static VerticalAlignment? ToVerticalAlignment(this ExcelVerticalAlignment verticalAlignment)
        {
            switch (verticalAlignment)
            {
                case ExcelVerticalAlignment.Top:
                    return VerticalAlignment.Top;
                case ExcelVerticalAlignment.Center:
                    return VerticalAlignment.Middle;
                case ExcelVerticalAlignment.Bottom:
                    return VerticalAlignment.Bottom;
                default:
                    return null;
            }
        }
    }
}
