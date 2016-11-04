using iTextSharp.text;
using iTextSharp.text.pdf;
using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Pdf
{
    public class TableCell
    {
        internal TableCell()
        {
            Border = new Border();
        }

        public string Value { get; set; }

        public int? Colspan { get; set; }

        public int? Rowspan { get; set; }

        public ReportColor BackgoundColor { get; set; }

        public FontList? FontList { get; set; }

        public float? FontSize { get; set; }

        public ReportColor TextColor { get; set; }

        public FontStyle? Style { get; set; }

        public HorizontalAlignment? HorizontalAlignment { get; set; }

        public VerticalAlignment? VerticalAlignment { get; set; }

        public float? PaddingTop { get; set; }

        public float? PaddingRight { get; set; }

        public float? PaddingBottom { get; set; }

        public float? PaddingLeft { get; set; }

        public Border Border { get; set; }

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

        public static implicit operator PdfPCell(TableCell cellSource)
        {
            PdfPCell cell;
            if (string.IsNullOrEmpty(cellSource.Value))
            {
                cell = new PdfPCell();
            }
            else
            {
                Phrase phrase;
                FontList fontList = cellSource.FontList ?? ReportFactory.FontList;
                float fontSize = cellSource.FontSize ?? ReportFactory.FontSize;
                ReportColor textColor = cellSource.TextColor ?? ReportFactory.TextColor;
                FontStyle style = cellSource.Style ?? ReportFactory.FontStyle;
                ReportFont font = ReportFont.Create(fontList, fontSize, textColor, style);

                if (font == null)
                {
                    phrase = new Phrase(cellSource.Value);
                }
                else
                {
                    phrase = new Phrase(cellSource.Value, font);
                }

                cell = new PdfPCell(phrase);
            }

            int? colspan = cellSource.Colspan;
            if (colspan.HasValue && colspan > 1)
            {
                cell.Colspan = colspan.Value;
            }

            ReportColor backgroundColor = cellSource.BackgoundColor ?? ReportFactory.BackgoundColor;
            if (backgroundColor != null)
            {
                cell.BackgroundColor = backgroundColor;
            }

            HorizontalAlignment? horizontalAlignment = cellSource.HorizontalAlignment ?? ReportFactory.TableHorizontalAlignment;
            if (horizontalAlignment.HasValue)
            {
                cell.HorizontalAlignment = horizontalAlignment.Value.ToITextSharpValue();
            }

            VerticalAlignment? verticalAlignment = cellSource.VerticalAlignment ?? ReportFactory.TableVerticalAlignment;
            if (verticalAlignment.HasValue)
            {
                cell.VerticalAlignment = verticalAlignment.Value.ToITextSharpValue();
            }

            float? paddingTop = cellSource.PaddingTop ?? ReportFactory.TableCellPaddingTop;
            if (paddingTop.HasValue)
            {
                cell.PaddingTop = paddingTop.Value;
            }

            float? paddingRight = cellSource.PaddingRight ?? ReportFactory.TableCellPaddingRight;
            if (paddingRight.HasValue)
            {
                cell.PaddingRight = paddingRight.Value;
            }


            float? paddingBottom = cellSource.PaddingBottom ?? ReportFactory.TableCellPaddingBottom;
            if (paddingBottom.HasValue)
            {
                cell.PaddingBottom = paddingBottom.Value;
            }

            float? paddingLeft = cellSource.PaddingLeft ?? ReportFactory.TableCellPaddingLeft;
            if (paddingLeft.HasValue)
            {
                cell.PaddingLeft = paddingLeft.Value;
            }

            // border
            if (cellSource.Border.Top.Style == BorderStyle.None)
            {
                cell.BorderWidthTop = 0f;
            }

            if (cellSource.Border.Right.Style == BorderStyle.None)
            {
                cell.BorderWidthRight = 0f;
            }

            if (cellSource.Border.Bottom.Style == BorderStyle.None)
            {
                cell.BorderWidthBottom = 0f;
            }

            if (cellSource.Border.Left.Style == BorderStyle.None)
            {
                cell.BorderWidthLeft = 0f;
            }

            return cell;
        }

        //public PdfPCell AsPdfCell()
        //{
        //    PdfPCell cell = new PdfPCell();
        //    if (!string.IsNullOrEmpty(Value))
        //    {
        //        Phrase phrase;
        //        FontList fontList = FontList ?? ReportFactory.FontList;
        //        int fontSize = FontSize ?? ReportFactory.FontSize;
        //        ReportColor textColor = TextColor ?? ReportFactory.TextColor;
        //        FontStyle style = Style ?? ReportFactory.FontStyle;
        //        ReportFont font = ReportFont.Create(fontList, fontSize, textColor, style);

        //        if (font == null)
        //        {
        //            phrase = new Phrase(Value);
        //        }
        //        else
        //        {
        //            phrase = new Phrase(Value, font);
        //        }
        //    }

        //    int? colspan = Colspan ?? ReportFactory.TableCellColspan;
        //    if (colspan.HasValue && colspan > 1)
        //    {
        //        cell.Colspan = colspan.Value;
        //    }

        //    ReportColor backgroundColor = BackgoundColor ?? ReportFactory.BackgoundColor;
        //    if (backgroundColor != null)
        //    {
        //        cell.BackgroundColor = backgroundColor;
        //    }

        //    HorizontalAlignment? horizontalAlignment = HorizontalAlignment ?? ReportFactory.TableHorizontalAlignment;
        //    if (horizontalAlignment.HasValue)
        //    {
        //        cell.HorizontalAlignment = horizontalAlignment.Value.ToITextSharpValue();
        //    }

        //    VerticalAlignment? verticalAlignment = VerticalAlignment ?? ReportFactory.TableVerticalAlignment;
        //    if (verticalAlignment.HasValue)
        //    {
        //        cell.VerticalAlignment = verticalAlignment.Value.ToITextSharpValue();
        //    }

        //    return cell;
        //}
    }
}
