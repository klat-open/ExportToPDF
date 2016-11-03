using OfficeOpenXml.Style;
using System.Globalization;
using OfficeOpenXml;

namespace Klat.ReportIO.Commons
{
    public static class ColorUtils
    {
        public static ReportColor ToReportColorByRgb(this string rgb)
        {
            if (string.IsNullOrEmpty(rgb))
            {
                return null;
            }
            
            if (rgb.StartsWith("#"))
            {
                rgb = rgb.Substring(1);
            }

            int argb = int.Parse(rgb, NumberStyles.HexNumber);

            return ReportColor.Create(argb);
        }

        public static ReportColor GetColor(this ExcelColor excelColor)
        {
            return ToReportColorByRgb(excelColor.Rgb);
        }

        public static ReportColor GetTextColor(this ExcelRange excelRange)
        {
            string rgb = string.IsNullOrEmpty(excelRange.Style.Font.Color.Rgb) ? excelRange.Style.Font.Color.LookupColor(excelRange.Style.Font.Color) : excelRange.Style.Font.Color.Rgb;
            
            return ToReportColorByRgb(rgb);
        }
    }
}
