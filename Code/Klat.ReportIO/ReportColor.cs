using iTextSharp.text;
using System.Drawing;

namespace Klat.ReportIO
{
    public class ReportColor
    {
        public const string WhileHtmlColor = "#ffffff";

        public static readonly ReportColor While = ReportColor.Create("#ffffff");

        public static readonly ReportColor Black = ReportColor.Create("#000000");

        private ReportColor() { }

        public Color Color { get; set; }

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

        public static implicit operator BaseColor(ReportColor color)
        {
            return color.AsBaseColor();
        }


        public static explicit operator ReportColor(BaseColor color)
        {
            return ReportColor.Create(color);
        }


        public static explicit operator ReportColor(string color)
        {
            return ReportColor.Create(color);
        }


        public static explicit operator string(ReportColor color)
        {
            return ColorTranslator.ToHtml(color.Color);
        }

        public BaseColor AsBaseColor()
        {
            return new BaseColor(Color);
        }
    }
}
