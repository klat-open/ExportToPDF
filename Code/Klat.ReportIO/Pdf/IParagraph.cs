using Klat.ReportIO.Enums;
using System.Collections.Generic;

namespace Klat.ReportIO.Pdf
{
    public interface IParagraph : IElementRoot
    {
        List<IText> Texts { get; set; }

        TextAlignment? TextAlign { get; set; }

        ReportColor BackgoundColor { get; set; }

        FontList? FontList { get; set; }

        int? FontSize { get; set; }

        ReportColor TextColor { get; set; }

        FontStyle? Style { get; set; }

        IText CreateText();

        void AddText(IText text);

        void AddTexts(params IText[] texts);

        IText NewText();
    }
}
