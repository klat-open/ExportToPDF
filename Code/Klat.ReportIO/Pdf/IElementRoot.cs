namespace Klat.ReportIO.Pdf
{
    public interface IElementRoot : IElement
    {
        float? PaddingTop { get; set; }

        float? PaddingRight { get; set; }

        float? PaddingBottom { get; set; }

        float? PaddingLeft { get; set; }
    }
}
