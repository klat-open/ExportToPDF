using System.Collections.Generic;
using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Pdf
{
    public class TableRow : ITableRow
    {
        internal TableRow()
        {
            Cells = new List<ITableCell>();
        }

        public string Id { get; set; }

        public List<ITableCell> Cells { get; set; }

        public ReportColor BackgoundColor { get; set; }

        public FontList? FontList { get; set; }

        public int? FontSize { get; set; }

        public ReportColor TextColor { get; set; }

        public FontStyle? Style { get; set; }

        public HorizontalAlignment? HorizontalAlignment { get; set; }

        public VerticalAlignment? VerticalAlignment { get; set; }

        public static ITableRow Create()
        {
            ITableRow row = new TableRow();

            return row;
        }

        public ITableCell CreateCell()
        {
            ITableCell cell = TableCell.Create();
            if (BackgoundColor != null)
            {
                cell.BackgoundColor = BackgoundColor;
            }

            if (FontList.HasValue)
            {
                cell.FontList = FontList;
            }

            if (FontSize.HasValue)
            {
                cell.FontSize = FontSize;
            }

            if (TextColor != null)
            {
                cell.TextColor = TextColor;
            }

            if (Style.HasValue)
            {
                cell.Style = Style;
            }

            if (HorizontalAlignment.HasValue)
            {
                cell.HorizontalAlignment = HorizontalAlignment;
            }

            if (VerticalAlignment.HasValue)
            {
                cell.VerticalAlignment = VerticalAlignment;
            }

            return cell;
        }

        public void AddCell(ITableCell cell)
        {
            Cells.Add(cell);
        }

        public void AddCells(params ITableCell[] cells)
        {
            Cells.AddRange(cells);
        }

        public ITableCell NewCell()
        {
            ITableCell cell = CreateCell();
            AddCell(cell);

            return cell;
        }
    }
}
