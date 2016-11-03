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

        public Table Create(int columnLength)
        {
            return new Table { ColumnLenght = columnLength };
        }

        public TableRow CreateRow()
        {
            TableRow row = TableRow.Create();

            return row;
        }

        public Table AppendRow(int columnLength = 1,
            HorizontalAlignment alignDefault = HorizontalAlignment.Left,
            VerticalAlignment valignDefault = VerticalAlignment.Top)
        {
            Table table = new Table(1, alignDefault, valignDefault);

            return table;
        }

        public void AddRow(TableRow row)
        {
            Rows.Add(row);
        }
    }
}
