using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Pdf
{
    public interface ITableCell : IElement
    {
        string Value { get; set; }

        int? Colspan { get; set; }

        int? Rowspan { get; set; }

        ReportColor BackgoundColor { get; set; }

        FontList? FontList { get; set; }

        float? FontSize { get; set; }

        ReportColor TextColor { get; set; }

        FontStyle? Style { get; set; }

        HorizontalAlignment? HorizontalAlignment { get; set; }

        VerticalAlignment? VerticalAlignment { get; set; }

        float? PaddingTop { get; set; }

        float? PaddingRight { get; set; }

        float? PaddingBottom { get; set; }

        float? PaddingLeft { get; set; }

        Border Border { get; set; }
    }
}
