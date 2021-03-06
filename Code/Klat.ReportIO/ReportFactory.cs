﻿using Klat.ReportIO.Enums;

namespace Klat.ReportIO
{
    public static class ReportFactory
    {
        static ReportFactory()
        {
            Reset();
        }

        public static PageSize PageSize { get; set; }

        public static PageOrientation PageOrientation { get; set; }

        public static FontList FontList { get; set; }

        public static float FontSize { get; set; }

        public static FontStyle FontStyle { get; set; }

        public static ReportColor TextColor { get; set; }

        public static ReportColor BackgoundColor { get; set; }

        public static float MarginTop { get; set; }

        public static float MarginRight { get; set; }

        public static float MarginBottom { get; set; }

        public static float MarginLeft { get; set; }

        public static float? ParagraphPaddingTop { get; set; }

        public static float? ParagraphPaddingRight { get; set; }

        public static float? ParagraphPaddingBottom { get; set; }

        public static float? ParagraphPaddingLeft { get; set; }

        public static float TableFontSize { get; set; }

        public static HorizontalAlignment TableHorizontalAlignment { get; set; }

        public static VerticalAlignment TableVerticalAlignment { get; set; }

        public static float? TableCellPaddingTop { get; set; }

        public static float? TableCellPaddingRight { get; set; }

        public static float? TableCellPaddingBottom { get; set; }

        public static float? TableCellPaddingLeft { get; set; }

        public static void Reset()
        {
            PageSize = PageSize.A4;
            PageOrientation = PageOrientation.Portrait;
            FontList = FontList.TimesNewRoman;
            FontSize = 13f;
            FontStyle = FontStyle.Regular;
            TextColor = ReportColor.Black;
            BackgoundColor = ReportColor.While;
            MarginTop = 30;
            MarginRight = 30;
            MarginBottom = 30;
            MarginLeft = 30;
            ParagraphPaddingTop = null;
            ParagraphPaddingRight = null;
            ParagraphPaddingBottom = null;
            ParagraphPaddingLeft = null;
            TableFontSize = 13f;
            TableHorizontalAlignment = HorizontalAlignment.Left;
            TableVerticalAlignment = VerticalAlignment.Top;
            TableCellPaddingTop = null;
            TableCellPaddingRight = null;
            TableCellPaddingBottom = null;
            TableCellPaddingLeft = null;
        }

        public static void SetStyle1ForPDF()
        {
            PageSize = PageSize.A4;
            PageOrientation = PageOrientation.Portrait;
            FontList = FontList.TimesNewRoman;
            FontSize = 13f;
            FontStyle = FontStyle.Regular;
            TextColor = ReportColor.Black;
            BackgoundColor = ReportColor.While;
            MarginTop = 30;
            MarginRight = 30;
            MarginBottom = 30;
            MarginLeft = 30;
            ParagraphPaddingTop = null;
            ParagraphPaddingRight = null;
            ParagraphPaddingBottom = null;
            ParagraphPaddingLeft = null;
            TableFontSize = 9f;
            TableHorizontalAlignment = HorizontalAlignment.Left;
            TableVerticalAlignment = VerticalAlignment.Top;
            TableCellPaddingTop = null;
            TableCellPaddingRight = null;
            TableCellPaddingBottom = 5f;
            TableCellPaddingLeft = null;
        }
    }
}
