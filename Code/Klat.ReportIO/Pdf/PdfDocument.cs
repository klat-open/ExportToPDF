﻿using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klat.ReportIO.Pdf
{
    public class PdfDocument
    {
        public PdfDocument()
        {

        }

        public PdfDocument(PageSize pageSize)
        {
            PageSize = pageSize;
        }

        public PageSize? PageSize { get; set; }

        public PageOrientation? PageOrientation { get; set; }

        public float? MarginTop { get; set; }

        public float? MarginRight { get; set; }

        public float? MarginBottom { get; set; }

        public float? MarginLeft { get; set; }

        public ArrayList Paragraphs = new ArrayList();

        public void AddParagraph(Table table)
        {
            Paragraphs.Add(table);
        }

        public void AddParagraph(Paragraph paragraph)
        {
            Paragraphs.Add(paragraph);
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

                        Table table = Table.Create(columnLength);
                        // Duyệt từng dòng.
                        for (int i = 1; i <= rowLength; i++)
                        {
                            TableRow tableRow = table.NewRow();
                            // Duyệt từng cột.
                            //int columnIndex = 1;
                            for (int j = 1; j <= columnLength; j++)
                            {
                                TableCell tableCell = tableRow.NewCell();

                                ExcelRange cell = sheet.Cells[i, j];
                                int colspan = cell.Columns;
                                int rowspan = cell.Rows;
                                string text = cell.Text;

                                tableCell.Value = text;
                                tableCell.Colspan = colspan;
                                tableCell.Rowspan = rowspan;

                                tableCell.BackgoundColor = cell.Style.Fill.BackgroundColor.ToReportColor();
                                if (!string.IsNullOrEmpty(text))
                                {
                                    if (cell.Style.Font.Bold && cell.Style.Font.Italic)
                                    {
                                        tableCell.Style = FontStyle.BoldItalic;
                                    }
                                    else if (cell.Style.Font.Bold)
                                    {
                                        tableCell.Style = FontStyle.Bold;
                                    }
                                    else if (cell.Style.Font.Italic)
                                    {
                                        tableCell.Style = FontStyle.Italic;
                                    }

                                    //if (cell.RichText.Any())
                                    //{
                                    //    tableCell.TextColor = cell.Style.Font.Color.ToReportColor();

                                    //    // tableCell.TextColor = (ReportColor)cell.RichText.First().Color;
                                    //    // tableCell.TextColor = ReportColor.While;
                                    //}
                                    //else
                                    //{
                                    //    tableCell.TextColor = cell.Style.Font.Color.ToReportColor();
                                    //}
                                }

                                j = j + colspan - 1;
                            }
                        }

                        AddParagraph(table);
                    }
                }
            }
        }

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

        public void Save(string fileName)
        {
            string defaultFontPath = FontUtils.GetFontPath(ReportFactory.FontList, ReportFactory.FontStyle);
            iTextSharp.text.FontFactory.Register(defaultFontPath);

            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                PageSize currentPageSize = PageSize ?? ReportFactory.PageSize;

                PageOrientation pageOrientation = PageOrientation ?? ReportFactory.PageOrientation;
                iTextSharp.text.Rectangle pageSize = PageSizeUtils.ToRectangle(currentPageSize, pageOrientation);
                using (var document = new iTextSharp.text.Document(pageSize))
                {
                    float marginTop = MarginLeft ?? ReportFactory.MarginLeft;
                    float marginRight = MarginLeft ?? ReportFactory.MarginRight;
                    float marginBottom = MarginLeft ?? ReportFactory.MarginBottom;
                    float marginLeft = MarginLeft ?? ReportFactory.MarginLeft;
                    document.SetMargins(marginLeft, marginRight, marginTop, marginBottom);

                    var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fileStream);
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
