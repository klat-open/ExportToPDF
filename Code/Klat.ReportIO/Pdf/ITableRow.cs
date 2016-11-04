using Klat.ReportIO.Enums;
using System.Collections.Generic;

namespace Klat.ReportIO.Pdf
{
    public interface ITableRow : IElement
    {
        List<ITableCell> Cells { get; set; }

        ReportColor BackgoundColor { get; set; }

        FontList? FontList { get; set; }

        int? FontSize { get; set; }

        ReportColor TextColor { get; set; }

        FontStyle? Style { get; set; }

        HorizontalAlignment? HorizontalAlignment { get; set; }

        VerticalAlignment? VerticalAlignment { get; set; }

        ITableCell CreateCell();

        void AddCell(ITableCell cell);

        void AddCells(params ITableCell[] cells);

        ITableCell NewCell();
    }
}
