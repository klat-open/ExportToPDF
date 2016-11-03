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

        public static FontList FontList { get; set; }

        public static int FontSize { get; set; }

        public static FontStyle FontStyle { get; set; }

        public static ReportColor TextColor { get; set; }

        public static ReportColor BackgoundColor { get; set; }

        public static int MarginTop { get; set; }

        public static int MarginRight { get; set; }

        public static int MarginBottom { get; set; }

        public static int MarginLeft { get; set; }

        public static int TableFontSize { get; set; }

        public static HorizontalAlignment TableHorizontalAlignment { get; set; }

        public static VerticalAlignment TableVerticalAlignment { get; set; }

        public static int TableCellColspan { get; set; }

        public static int TableCellPaddingTop { get; set; }

        public static int TableCellPaddingRight { get; set; }

        public static int TableCellPaddingBottom { get; set; }

        public static int TableCellPaddingLeft { get; set; }

        public static void Reset()
        {
            PageSize = PageSize.A4;
            FontList = FontList.TimesNewRoman;
            FontSize = 13;
            FontStyle = FontStyle.Regular;
            TextColor = ReportColor.Black;
            BackgoundColor = ReportColor.While;
            MarginTop = 30;
            MarginRight = 30;
            MarginBottom = 30;
            MarginTop = 30;
            TableFontSize = 13;
            TableHorizontalAlignment = HorizontalAlignment.Left;
            TableVerticalAlignment = VerticalAlignment.Top;
            TableCellColspan = 1;
            TableCellPaddingTop = 0;
            TableCellPaddingRight = 0;
            TableCellPaddingBottom = 5;
            TableCellPaddingLeft = 0;
        }

        public static void SetStyle1ForPDF()
        {
            PageSize = PageSize.A4;
            FontList = FontList.TimesNewRoman;
            FontSize = 13;
            FontStyle = FontStyle.Regular;
            TextColor = ReportColor.Black;
            BackgoundColor = ReportColor.While;
            MarginTop = 30;
            MarginRight = 30;
            MarginBottom = 30;
            MarginTop = 30;
            TableFontSize = 9;
            TableHorizontalAlignment = HorizontalAlignment.Left;
            TableVerticalAlignment = VerticalAlignment.Top;
            TableCellColspan = 1;
            TableCellPaddingTop = 0;
            TableCellPaddingRight = 0;
            TableCellPaddingBottom = 5;
            TableCellPaddingLeft = 0;
        }
    }
}
