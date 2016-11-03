using Klat.ReportIO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klat.ReportIO.Pdf
{
    public class Table
    {
        internal Table()
        {
            Rows = new List<TableRow>();
        }

        public int ColumnLenght { get; private set; }

        public ReportColor BackgoundColor { get; set; }

        public FontList? FontList { get; set; }

        public int? FontSize { get; set; }

        public ReportColor TextColor { get; set; }

        public FontStyle? Style { get; set; }

        public HorizontalAlignment? HorizontalAlignment { get; set; }

        public VerticalAlignment? VerticalAlignment { get; set; }

        public List<TableRow> Rows { get; set; }

        public static Table Create(int columnLength)
        {
            return new Table { ColumnLenght = columnLength };
        }

        public TableRow CreateRow()
        {
            TableRow row = TableRow.Create();
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

        public void AddRow(TableRow row)
        {
            Rows.Add(row);
        }

        public void AddRows(params TableRow[] rows)
        {
            Rows.AddRange(rows);
        }

        public TableRow NewRow()
        {
            TableRow row = CreateRow();
            AddRow(row);

            return row;
        }

        public static implicit operator iTextSharp.text.pdf.PdfPTable(Table tableSource)
        {
            int columnLength = tableSource.ColumnLenght;
            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(columnLength);
            table.WidthPercentage = 100f;
            iTextSharp.text.pdf.PdfPCell cell;
            foreach (TableRow row in tableSource.Rows)
            {
                int columnLengthWithRow = 0;
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    TableCell cellSource = row.Cells[i];
                    if (columnLengthWithRow + cellSource.Colspan >= columnLength)
                    {
                        break;
                    }

                    columnLengthWithRow += cellSource.Colspan ?? ReportFactory.TableCellColspan;
                    cell = cellSource;
                    table.AddCell(cell);
                }

                for (int i = columnLengthWithRow; i < columnLength; i++)
                {
                    cell = row.NewCell();
                    table.AddCell(cell);
                }
            }

            return table;
        }
    }
}
