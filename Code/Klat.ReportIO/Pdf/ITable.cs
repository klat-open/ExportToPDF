using Klat.ReportIO.Enums;
using System.Collections.Generic;

namespace Klat.ReportIO.Pdf
{
    public interface ITable : IElementRoot
    {
        ReportColor BackgoundColor { get; set; }

        FontList? FontList { get; set; }

        int? FontSize { get; set; }

        ReportColor TextColor { get; set; }

        FontStyle? Style { get; set; }

        HorizontalAlignment? HorizontalAlignment { get; set; }

        VerticalAlignment? VerticalAlignment { get; set; }

        List<ITableRow> Rows { get; set; }

        ITableRow CreateRow();

        void AddRow(ITableRow row);

        void AddRows(params ITableRow[] rows);

        ITableRow NewRow();

        int GetColumnLenght();
    }
}
