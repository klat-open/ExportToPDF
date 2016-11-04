using System;
using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml.Style;
using static OfficeOpenXml.ExcelWorksheet;
using System.Linq;

namespace Klat.ReportIO.Pdf
{
    public class PdfDocument : IPdfDocument
    {
        public PdfDocument()
        {
            Paragraphs = new List<IElementRoot>();
        }

        public PdfDocument(PageSize pageSize)
            : this()
        {
            PageSize = pageSize;
        }

        public PageSize? PageSize { get; set; }

        public PageOrientation? PageOrientation { get; set; }

        public float? MarginTop { get; set; }

        public float? MarginRight { get; set; }

        public float? MarginBottom { get; set; }

        public float? MarginLeft { get; set; }

        public List<IElementRoot> Paragraphs { get; set; }

        public static implicit operator iTextSharp.text.Document(PdfDocument pdfDocument)
        {
            PageSize currentPageSize = pdfDocument.PageSize ?? ReportFactory.PageSize;
            iTextSharp.text.Rectangle pageSize = PageSizeUtils.ToRectangle(currentPageSize);
            var document = new iTextSharp.text.Document(pageSize, 10, 10, 10, 10);
            document.Open();

            foreach (var paragraph in pdfDocument.Paragraphs)
            {
                if (paragraph is Table)
                {
                    iTextSharp.text.pdf.PdfPTable tableSource = paragraph as Table;
                    document.Add(tableSource);
                }
                else if (paragraph is Paragraph)
                {

                }
            }

            document.Close();

            return document;
        }

        public void AddElement(IElementRoot element)
        {
            Paragraphs.Add(element);
        }

        public void AddElements(params IElementRoot[] elements)
        {
            Paragraphs.AddRange(elements);
        }

        public Table NewTable(int columLength)
        {
            Table table = Table.Create(columLength);
            Paragraphs.Add(table);

            return table;
        }

        /// <summary>
        /// Hỗ trợ định dạng mới của excel (*.xlsx).
        /// </summary>
        /// <param name="fileName"></param>
        public void InsertFromExcel(string fileName)
        {
            FileInfo excelFile = new FileInfo(fileName);
            using (var excel = new ExcelPackage(excelFile, false))
            {
                ExcelWorkbook workbook = excel.Workbook;
                ExcelWorksheets worksheets = workbook.Worksheets;
                foreach (ExcelWorksheet sheet in worksheets)
                {
                    ExcelAddressBase activeRange = sheet.Dimension;

                    if (activeRange != null)
                    {
                        int columnLength = activeRange.Columns;
                        int rowLength = activeRange.Rows;

                        ExcelRange cells = sheet.Cells[activeRange.Start.Row, activeRange.Start.Column, activeRange.End.Row, activeRange.End.Column];
                        // ExcelStyle fullStyle = cells.Style;

                        ITable table = Table.Create(columnLength);
                        // Duyệt từng dòng.
                        for (int i = 1; i <= rowLength; i++)
                        {
                            ITableRow tableRow = table.NewRow();
                            // Duyệt từng cột.
                            //int columnIndex = 1;
                            for (int j = 1; j <= columnLength; j++)
                            {
                                ITableCell tableCell = tableRow.NewCell();

                                ExcelRange cell = sheet.Cells[i, j];
                                int colspan = cell.Columns;
                                int rowspan = cell.Rows;
                                string text = cell.Text;

                                tableCell.Value = text;
                                tableCell.Colspan = colspan;
                                tableCell.Rowspan = rowspan;

                                // tableCell.BackgoundColor = cell.Style.Fill.BackgroundColor.ToReportColorByExcelColor();
                                var style = cell.Style;
                                var fill = style.Fill;
                                var font = style.Font;

                                string rgbForbackgound; // See more: http://stackoverflow.com/questions/35941241/epplus-get-correct-cell-background-rgb-color
                                if (fill.PatternType == ExcelFillStyle.Solid)
                                {
                                    rgbForbackgound = !string.IsNullOrEmpty(fill.BackgroundColor.Rgb) ? fill.BackgroundColor.Rgb : fill.PatternColor.LookupColor(fill.BackgroundColor);
                                }
                                else if (fill.PatternType != ExcelFillStyle.None)
                                {
                                    rgbForbackgound = !string.IsNullOrEmpty(fill.PatternColor.Rgb) ? fill.PatternColor.Rgb : fill.PatternColor.LookupColor(fill.PatternColor);
                                }
                                else
                                {
                                    rgbForbackgound = null;
                                }

                                // border
                                if (style.Border.Top.Style == ExcelBorderStyle.None)
                                {
                                    tableCell.Border.Top.Style = BorderStyle.None;
                                }
                                else
                                {
                                    tableCell.Border.Top.Style = BorderStyle.Solid;
                                }

                                if (style.Border.Right.Style == ExcelBorderStyle.None)
                                {
                                    tableCell.Border.Right.Style = BorderStyle.None;
                                }
                                else
                                {
                                    tableCell.Border.Right.Style = BorderStyle.Solid;
                                }

                                if (style.Border.Bottom.Style == ExcelBorderStyle.None)
                                {
                                    tableCell.Border.Bottom.Style = BorderStyle.None;
                                }
                                else
                                {
                                    tableCell.Border.Bottom.Style = BorderStyle.Solid;
                                }

                                if (style.Border.Left.Style == ExcelBorderStyle.None)
                                {
                                    tableCell.Border.Left.Style = BorderStyle.None;
                                }
                                else
                                {
                                    tableCell.Border.Left.Style = BorderStyle.Solid;
                                }

                                if (cell.IsRichText)
                                {
                                    // ExcelRichTextCollection richTextCollection = cell.RichText;
                                    // var dictionaryTextToColour = richTextCollection.ToDictionary(rt => rt.Text, rt => rt.Color); //NOT recommended to use a dictionary here
                                }
                                else
                                {
                                    tableCell.TextColor = cell.GetTextColor(cells);
                                }

                                if (!string.IsNullOrEmpty(rgbForbackgound))
                                {
                                    tableCell.BackgoundColor = rgbForbackgound.ToReportColorByRgb();
                                }

                                // merge cell
                                if (cell.Merge)
                                {
                                    // string columnSpan = cell.Table.ColumnSpan;
                                }

                                if (string.IsNullOrEmpty(text))
                                {
                                    // Gán cell đầu tiên của hàng là 1 space để nếu hàng có tất cả các cell empty thì in ra PDF vẫn có hàng đó (mặc định không hiển thị).
                                    if (j == 1)
                                    {
                                        tableCell.Value = " ";
                                    }
                                }
                                else
                                {
                                    if (font.Bold && font.Italic)
                                    {
                                        tableCell.Style = FontStyle.BoldItalic;
                                    }
                                    else if (font.Bold)
                                    {
                                        tableCell.Style = FontStyle.Bold;
                                    }
                                    else if (font.Italic)
                                    {
                                        tableCell.Style = FontStyle.Italic;
                                    }

                                    tableCell.FontSize = font.Size;

                                    // align
                                    tableCell.HorizontalAlignment = style.HorizontalAlignment.ToHorizontalAlignment();
                                    tableCell.VerticalAlignment = style.VerticalAlignment.ToVerticalAlignment();
                                }

                                j = j + colspan - 1;
                            }
                        }

                        // caculate merge cells.
                        MergeCellsCollection mergeCells = sheet.MergedCells;
                        foreach (string mergeCell in mergeCells)
                        {
                            var mergeRange = sheet.Cells[mergeCell];
                            int startRow = mergeRange.Start.Row;
                            int startColumn = mergeRange.Start.Column;
                            int endRow = mergeRange.End.Row;
                            int endColumn = mergeRange.End.Column;

                            int colspan = endColumn - startColumn + 1;
                            int rowspan = endRow - startRow + 1;
                            for (int i = startRow; i <= endRow; i++)
                            {
                                for (int j = startColumn; j < endColumn; j++)
                                {
                                    ITableCell cellMerge = table.Rows[i - 1].Cells[j - 1];
                                    if (i == startRow && j == startColumn)
                                    {
                                        if (colspan > 1)
                                        {
                                            cellMerge.Colspan = colspan;
                                        }

                                        if (rowspan > 1)
                                        {
                                            cellMerge.Rowspan = rowspan;
                                        }
                                    }
                                    else
                                    {
                                        ((TableCell)cellMerge).IsMerge = true;
                                    }
                                }
                            }
                        }

                        // Xoá tất cả cell merge có Colspan <= 1 && Rowspan <= 1
                        // IEnumerable<ITableCell> mergeCellsTmp = table.Rows.SelectMany(row => row.Cells).Where(cell => cell.IsMerge && (!cell.Colspan.HasValue || cell.Colspan <= 1) && (!cell.Rowspan.HasValue || cell.Rowspan <= 1));
                        foreach (ITableRow row in table.Rows)
                        {
                            row.Cells.RemoveAll(cell => cell.IsMerge && (!cell.Colspan.HasValue || cell.Colspan <= 1) && (!cell.Rowspan.HasValue || cell.Rowspan <= 1));
                        }

                        AddElement(table);
                    }
                }
            }
        }

        public void Save(string fileName, Func<List<IElementRoot>, List<IElementRoot>> formatFunc = null)
        {
            if (formatFunc != null)
            {
                formatFunc.Invoke(Paragraphs);
            }

            string defaultFontPath = FontUtils.GetFontPath(ReportFactory.FontList, ReportFactory.FontStyle);
            iTextSharp.text.FontFactory.Register(defaultFontPath);

            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                PageSize currentPageSize = PageSize ?? ReportFactory.PageSize;

                PageOrientation pageOrientation = PageOrientation ?? ReportFactory.PageOrientation;
                iTextSharp.text.Rectangle pageSize = currentPageSize.ToRectangle(pageOrientation);
                using (var document = new iTextSharp.text.Document(pageSize))
                {
                    float marginTop = MarginLeft ?? ReportFactory.MarginLeft;
                    float marginRight = MarginLeft ?? ReportFactory.MarginRight;
                    float marginBottom = MarginLeft ?? ReportFactory.MarginBottom;
                    float marginLeft = MarginLeft ?? ReportFactory.MarginLeft;
                    document.SetMargins(marginLeft, marginRight, marginTop, marginBottom);

                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fileStream);
                    document.Open();

                    foreach (var para in Paragraphs)
                    {
                        if (para is Table)
                        {
                            iTextSharp.text.pdf.PdfPTable tableSource = para as Table;
                            document.Add(tableSource);
                        }
                        else if (para is Paragraph)
                        {
                            iTextSharp.text.Paragraph paragraph = para as Paragraph;
                            document.Add(paragraph);
                        }
                    }

                    document.Close();
                }

                fileStream.Close();
            }
        }

        // TODO: Can code lai
        public void SaveByMemoryStream(string fileName)
        {
            string defaultFontPath = FontUtils.GetFontPath(ReportFactory.FontList, ReportFactory.FontStyle);
            iTextSharp.text.FontFactory.Register(defaultFontPath);

            byte[] data;
            using (var memoryStream = new MemoryStream())
            {
                PageSize currentPageSize = PageSize ?? ReportFactory.PageSize;

                iTextSharp.text.Rectangle pageSize = PageSizeUtils.ToRectangle(currentPageSize);
                var document = new iTextSharp.text.Document(pageSize, 10, 10, 10, 10);
                var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                foreach (var paragraph in Paragraphs)
                {
                    if (paragraph is Table)
                    {
                        iTextSharp.text.pdf.PdfPTable tableSource = paragraph as Table;
                        document.Add(tableSource);
                    }
                    else if (paragraph is Paragraph)
                    {

                    }
                }

                document.Close();
                document.Dispose();

                data = memoryStream.ToArray();
            }

            File.WriteAllBytes(fileName, data);
        }
    }
}
