using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Pdf
{
    public class Text: IElement, IElementContent
    {
        public Text()
        {

        }

        public Text(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public ReportColor BackgoundColor { get; set; }

        public FontList? FontList { get; set; }

        public int? FontSize { get; set; }

        public ReportColor TextColor { get; set; }

        public FontStyle? Style { get; set; }

        public static implicit operator iTextSharp.text.Chunk(Text textSource)
        {
            FontList fontList = textSource.FontList ?? ReportFactory.FontList;
            float fontSize = textSource.FontSize ?? ReportFactory.FontSize;
            ReportColor textColor = textSource.TextColor ?? ReportFactory.TextColor;
            FontStyle style = textSource.Style ?? ReportFactory.FontStyle;
            ReportFont font = ReportFont.Create(fontList, fontSize, textColor, style);

            iTextSharp.text.Chunk chunk = new iTextSharp.text.Chunk(textSource.Value, font);

            return chunk;
        }
    }
}
