﻿using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Pdf
{
    public class TableCell : ITableCell
    {
        private int? _colspan;
        private int? _rowspan;
        private bool _isMerge;

        internal TableCell()
        {
            Border = new Border();
        }

        public string Id { get; set; }

        public string Value { get; set; }

        public int? Colspan
        {
            get { return _colspan; }
            set
            {
                _colspan = value;
                _isMerge = value > 1 || Rowspan > 1;
            }
        }

        public int? Rowspan
        {
            get { return _rowspan; }
            set
            {
                _rowspan = value;
                _isMerge = value > 1 || Colspan > 1;
            }
        }

        public bool IsMerge
        {
            get { return _isMerge; }
            internal set { _isMerge = value; }
        }

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

        public static implicit operator iTextSharp.text.pdf.PdfPCell(TableCell cellSource)
        {
            iTextSharp.text.pdf.PdfPCell cell;
            if (string.IsNullOrEmpty(cellSource.Value))
            {
                cell = new iTextSharp.text.pdf.PdfPCell();
            }
            else
            {
                iTextSharp.text.Phrase phrase;
                FontList fontList = cellSource.FontList ?? ReportFactory.FontList;
                float fontSize = cellSource.FontSize ?? ReportFactory.FontSize;
                ReportColor textColor = cellSource.TextColor ?? ReportFactory.TextColor;
                FontStyle style = cellSource.Style ?? ReportFactory.FontStyle;
                ReportFont font = ReportFont.Create(fontList, fontSize, textColor, style);

                if (font == null)
                {
                    phrase = new iTextSharp.text.Phrase(cellSource.Value);
                }
                else
                {
                    phrase = new iTextSharp.text.Phrase(cellSource.Value, font);
                }

                cell = new iTextSharp.text.pdf.PdfPCell(phrase);
            }

            int? colspan = cellSource.Colspan;
            if (colspan.HasValue && colspan > 1)
            {
                cell.Colspan = colspan.Value;
            }

            int? rowspan = cellSource.Rowspan;
            if (rowspan.HasValue && rowspan > 1)
            {
                cell.Rowspan = rowspan.Value;
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
