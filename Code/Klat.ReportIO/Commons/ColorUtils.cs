using OfficeOpenXml.Style;
using System.Globalization;

namespace Klat.ReportIO.Commons
{
    public static class ColorUtils
    {
        public static ReportColor ToReportColor(this string rgb)
        {
            if (string.IsNullOrEmpty(rgb))
            {
                return null;
            }

            int argb = int.Parse(rgb, NumberStyles.HexNumber);

            return ReportColor.Create(argb);
        }
        public static ReportColor ToReportColor(this ExcelColor excelColor)
        {
            return ToReportColor(excelColor.Rgb);
        }
    }
}
