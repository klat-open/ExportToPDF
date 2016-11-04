using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Pdf
{
    public interface IElementContent
    {
        string Value { get; set; }

        ReportColor BackgoundColor { get; set; }

        FontList? FontList { get; set; }

        int? FontSize { get; set; }

        ReportColor TextColor { get; set; }

        FontStyle? Style { get; set; }
    }
}
