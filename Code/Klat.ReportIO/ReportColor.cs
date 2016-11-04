using iTextSharp.text;
using System.Drawing;

namespace Klat.ReportIO
{
    public class ReportColor
    {
        public const string WhileHtmlColor = "#ffffff";

        public static readonly ReportColor While = ReportColor.Create("#ffffff");

        public static readonly ReportColor Black = ReportColor.Create("#000000");

        public static readonly ReportColor Red = ReportColor.Create("#ff0000");

        private ReportColor() { }

        public Color Color { get; set; }

        public static explicit operator ReportColor(BaseColor color)
        {
            return Create(color);
        }

        public static implicit operator BaseColor(ReportColor color)
        {
            return new BaseColor(color.Color);
        }

        public static explicit operator ReportColor(string color)
        {
            return Create(color);
        }

        public static implicit operator string(ReportColor color)
        {
            return ColorTranslator.ToHtml(color.Color);
        }

        public static explicit operator ReportColor(Color color)
        {
            return new ReportColor() { Color = color };
        }

        public static implicit operator Color(ReportColor color)
        {
            return color.Color;
        }

        public static ReportColor Create()
        {
            return ReportFactory.TextColor;
        }

        /// <summary>
        /// Example: #ffffff
        /// </summary>
        /// <param name="htmlColor"></param>
        public static ReportColor Create(string htmlColor)
        {
            return new ReportColor
            {
                Color = ColorTranslator.FromHtml(htmlColor)
            };
        }

        public static ReportColor Create(BaseColor color)
        {
            return new ReportColor
            {
                Color = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B)
            };
        }

        public static ReportColor Create(Color color)
        {
            return new ReportColor
            {
                Color = color
            };
        }

        public static ReportColor Create(int argb)
        {
            return new ReportColor
            {
                Color = System.Drawing.Color.FromArgb(argb)
            };
        }

        public static ReportColor Create(int red, int green, int blue)
        {
            return new ReportColor
            {
                Color = System.Drawing.Color.FromArgb(red, green, blue)
            };
        }

        public static ReportColor Create(int alpha, int red, int green, int blue)
        {
            return new ReportColor
            {
                Color = System.Drawing.Color.FromArgb(alpha, red, green, blue)
            };
        }
    }
}
