using iTextSharp.text;
using iTextSharp.text.pdf;
using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klat.ReportIO.Pdf
{
    public class TableCell
    {
        internal TableCell() { }

        public string Value { get; set; }

        public int? Colspan { get; set; }

        public ReportColor BackgoundColor { get; set; }

        public FontList? FontList { get; set; }

        public int? FontSize { get; set; }

        public ReportColor TextColor { get; set; }

        public FontStyle? Style { get; set; }

        public HorizontalAlignment? HorizontalAlignment { get; set; }

        public VerticalAlignment? VerticalAlignment { get; set; }

        public static TableCell Create()
        {
            return new TableCell();
        }

        public static TableCell Create(string value)
        {
            return new TableCell
            {
                Value = value
            };
        }

        public PdfPCell AsPdfCell()
        {
            PdfPCell cell = new PdfPCell();
            if (!string.IsNullOrEmpty(Value))
            {
                Phrase phrase;
                FontList fontList = FontList ?? ReportFactory.FontList;
                int fontSize = FontSize ?? ReportFactory.FontSize;
                ReportColor textColor = TextColor ?? ReportFactory.TextColor;
                FontStyle style = Style ?? ReportFactory.FontStyle;
                ReportFont font = ReportFont.Create(fontList, fontSize, textColor, style);

                if (font == null)
                {
                    phrase = new Phrase(Value);
                }
                else
                {
                    phrase = new Phrase(Value, font);
                }
            }

            int? colspan = Colspan ?? ReportFactory.TableCellColspan;
            if (colspan.HasValue && colspan > 1)
            {
                cell.Colspan = colspan.Value;
            }

            ReportColor backgroundColor = BackgoundColor ?? ReportFactory.BackgoundColor;
            if (backgroundColor != null)
            {
                cell.BackgroundColor = backgroundColor;
            }

            HorizontalAlignment? horizontalAlignment = HorizontalAlignment ?? ReportFactory.TableHorizontalAlignment;
            if (horizontalAlignment.HasValue)
            {
                cell.HorizontalAlignment = horizontalAlignment.Value.ToITextSharpValue();
            }

            VerticalAlignment? verticalAlignment = VerticalAlignment ?? ReportFactory.TableVerticalAlignment;
            if (verticalAlignment.HasValue)
            {
                cell.VerticalAlignment = verticalAlignment.Value.ToITextSharpValue();
            }

            return cell;
        }
    }
}
