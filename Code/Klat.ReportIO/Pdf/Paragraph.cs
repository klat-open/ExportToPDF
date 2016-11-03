﻿using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klat.ReportIO.Pdf
{
    public class Paragraph
    {
        public Paragraph()
        {
            Texts = new List<Text>();
        }

        public Paragraph(string text)
            : this()
        {
            Text t = new Text(text);
            Texts.Add(t);
        }

        public List<Text> Texts { get; set; }

        public TextAlignment? TextAlign { get; set; }

        public ReportColor BackgoundColor { get; set; }

        public FontList? FontList { get; set; }

        public int? FontSize { get; set; }

        public ReportColor TextColor { get; set; }

        public FontStyle? Style { get; set; }

        public Text CreateText()
        {
            Text text = new Text();

            return text;
        }

        public void AddText(Text text)
        {
            Texts.Add(text);
        }

        public void AddTexts(params Text[] texts)
        {
            Texts.AddRange(texts);
        }

        public Text NewText()
        {
            Text text = CreateText();

            if (BackgoundColor != null)
            {
                text.BackgoundColor = BackgoundColor;
            }

            if (FontList.HasValue)
            {
                text.FontList = FontList;
            }

            if (FontSize.HasValue)
            {
                text.FontSize = FontSize;
            }

            if (TextColor != null)
            {
                text.TextColor = TextColor;
            }

            if (Style.HasValue)
            {
                text.Style = Style;
            }

            AddText(text);

            return text;
        }

        public static implicit operator iTextSharp.text.Paragraph(Paragraph paragraphSource)
        {
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph();
            if (paragraphSource.TextAlign.HasValue)
            {
                paragraph.Alignment = paragraphSource.TextAlign.Value.ToITextSharpValue();
            }

            iTextSharp.text.Phrase phrase = new iTextSharp.text.Phrase();

            foreach (Text item in paragraphSource.Texts)
            {
                iTextSharp.text.Chunk chunk = item;
                phrase.Add(chunk);
            }

            paragraph.Add(phrase);

            return paragraph;
        }
    }
}
