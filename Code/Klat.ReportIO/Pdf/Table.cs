using Klat.ReportIO.Enums;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Klat.ReportIO.Pdf
{
    public class Table : ITable
    {
        internal Table()
        {
            Rows = new List<ITableRow>();
        }

        public string Id { get; set; }

        public ReportColor BackgoundColor { get; set; }

        public FontList? FontList { get; set; }

        public int? FontSize { get; set; }

        public ReportColor TextColor { get; set; }

        public FontStyle? Style { get; set; }

        public HorizontalAlignment? HorizontalAlignment { get; set; }

        public VerticalAlignment? VerticalAlignment { get; set; }

        public List<ITableRow> Rows { get; set; }

        public float? PaddingTop { get; set; }

        public float? PaddingRight { get; set; }

        public float? PaddingBottom { get; set; }

        public float? PaddingLeft { get; set; }

        public static implicit operator iTextSharp.text.pdf.PdfPTable(Table tableSource)
        {
            int columnLength = tableSource.GetColumnLenght();
            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(columnLength);
            table.WidthPercentage = 100f;
            iTextSharp.text.pdf.PdfPCell cell;
            foreach (ITableRow rowSource in tableSource.Rows)
            {
                foreach (var cellSource in rowSource.Cells)
                {
                    cell = cellSource as TableCell;
                    table.AddCell(cell);
                }
            }

            return table;
        }

        public static Table Create(int columnLength)
        {
            return new Table();
        }

        public ITableRow CreateRow()
        {
            ITableRow row = TableRow.Create();
            if (BackgoundColor != null)
            {
                row.BackgoundColor = BackgoundColor;
            }

            if (FontList.HasValue)
            {
                row.FontList = FontList;
            }

            if (FontSize.HasValue)
            {
                row.FontSize = FontSize;
            }

            if (TextColor != null)
            {
                row.TextColor = TextColor;
            }

            if (Style.HasValue)
            {
                row.Style = Style;
            }

            if (HorizontalAlignment.HasValue)
            {
                row.HorizontalAlignment = HorizontalAlignment;
            }

            if (VerticalAlignment.HasValue)
            {
                row.VerticalAlignment = VerticalAlignment;
            }

            return row;
        }

        public void AddRow(ITableRow row)
        {
            Rows.Add(row);
        }

        public void AddRows(params ITableRow[] rows)
        {
            Rows.AddRange(rows);
        }

        public ITableRow NewRow()
        {
            ITableRow row = CreateRow();
            AddRow(row);

            return row;
        }

        public int GetColumnLenght()
        {
            return Rows.Max(row => row.Cells.Sum(col => col.Colspan ?? 1));
        }
    }
}
