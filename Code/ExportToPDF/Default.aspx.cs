using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.pipeline.html;
using System.Text;

namespace Klat.Example
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExportToPDF_OnClick(object sender, EventArgs e)
        {
            byte[] pdf; // result will be here

            //var cssText = File.ReadAllText(MapPath("~/Reports/report.css"));
            //var html = File.ReadAllText(MapPath("~/Reports/Report1.html"), System.Text.Encoding.UTF8);

            // path o our font
            // string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Times New Roman");
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
            iTextSharp.text.FontFactory.Register(fontPath);

            // BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            // Times New Roman
            //Font bodyFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 9, Font.NORMAL, BaseColor.BLACK);
            //Font reportHeaderFont = FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, Font.BOLD, BaseColor.WHITE);
            //Font reportDateFont = FontFactory.GetFont(BaseFont.TIMES_ITALIC, 11, Font.ITALIC, BaseColor.BLACK);
            //Font reportHeaderColumnFont = FontFactory.GetFont(BaseFont.TIMES_BOLD, 11, Font.BOLD, BaseColor.WHITE);

            // BaseFont bF = BaseFont.CreateFont(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf"), "windows-1254", true);
            BaseFont bF = BaseFont.CreateFont(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            BaseFont bFB = BaseFont.CreateFont(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "timesbd.ttf"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            BaseFont bFI = BaseFont.CreateFont(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "timesi.ttf"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            BaseFont bFBI = BaseFont.CreateFont(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "timesbi.ttf"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //ok
            //Font bodyFont = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.NORMAL, BaseColor.BLACK);
            //Font reportHeaderFont = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);
            //Font reportDateFont = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.ITALIC, BaseColor.BLACK);
            //Font reportHeaderColumnFont = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.BOLD, BaseColor.WHITE);

            // Font fMSGothic = FontFactory.GetFont("MS-PGothic", BaseFont.IDENTITY_H, 8);

            Font bodyFont = new Font(bF, 9, Font.NORMAL, BaseColor.BLACK);
            Font reportHeaderFont = new Font(bFB, 12, Font.NORMAL, BaseColor.WHITE);
            Font reportDateFont = new Font(bFI, 11, Font.NORMAL, BaseColor.BLACK);
            Font reportHeaderColumnFont = new Font(bFB, 9, Font.NORMAL, BaseColor.WHITE);

            // BaseColor green = BaseColor.GREEN;
            BaseColor green = new BaseColor(0, 100, 45); // #00642d

            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //Font timeItalic = new Font(bfTimes, 12, Font.ITALIC, BaseColor.BLACK);
            //Font timeBold = new Font(bfTimes, 12, Font.BOLD, BaseColor.BLACK);
            //Font timeBoldItalic = new Font(bfTimes, 12, Font.BOLDITALIC, BaseColor.BLACK);

            //Font bodyFont = new Font(bfTimes, 9, Font.NORMAL, BaseColor.BLACK);
            //Font reportHeaderFont = new Font(bfTimes, 12, Font.BOLD, BaseColor.WHITE);
            //Font reportDateFont = new Font(bfTimes, 11, Font.ITALIC, BaseColor.BLACK);
            //Font reportHeaderColumnFont = new Font(bfTimes, 9, Font.BOLD, BaseColor.WHITE);


            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 10, 10, 10, 10);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                //using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText)))
                //{
                //    using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                //    {
                //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, cssMemoryStream, System.Text.Encoding.UTF8);
                //    }
                //}

                PdfPTable table = new PdfPTable(15);

                table.WidthPercentage = 100;

                // row 1
                PdfPCell cellRow1 = new PdfPCell(new Phrase("TỔNG HỢP PIPELINE REPORT", reportHeaderFont));
                cellRow1.BackgroundColor = green;
                cellRow1.Colspan = 15;
                cellRow1.HorizontalAlignment = PdfPCell.ALIGN_CENTER; // 0=Left, 1=Centre, 2=Right
                cellRow1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                table.AddCell(cellRow1);

                // row 2
                PdfPCell cellRow2 = new PdfPCell(new Phrase("Ngày báo cáo: " + DateTime.Now.ToShortDateString(), reportDateFont));
                // cellRow2.BackgroundColor = green;
                cellRow2.Colspan = 15;
                cellRow2.HorizontalAlignment = PdfPCell.ALIGN_CENTER; // 0=Left, 1=Centre, 2=Right
                cellRow2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                table.AddCell(cellRow2);

                // row 3
                PdfPCell r3c1 = new PdfPCell(new Phrase("TT", reportHeaderColumnFont));
                r3c1.BackgroundColor = green;
                r3c1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c1);

                PdfPCell r3c2 = new PdfPCell(new Phrase("Loại KH", reportHeaderColumnFont));
                r3c2.BackgroundColor = green;
                r3c2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c2.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c2);

                PdfPCell r3c3 = new PdfPCell(new Phrase("Nhóm", reportHeaderColumnFont));
                r3c3.BackgroundColor = green;
                r3c3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c3.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c3);

                PdfPCell r3c4 = new PdfPCell(new Phrase("CIF", reportHeaderColumnFont));
                r3c4.BackgroundColor = green;
                r3c4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c4.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c4);

                PdfPCell r3c5 = new PdfPCell(new Phrase("Tên KH", reportHeaderColumnFont));
                r3c5.BackgroundColor = green;
                r3c5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c5.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c5);

                PdfPCell r3c6 = new PdfPCell(new Phrase("Hạng khách hàng", reportHeaderColumnFont));
                r3c6.BackgroundColor = green;
                r3c6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c6.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c6);

                PdfPCell r3c7 = new PdfPCell(new Phrase("Ngành nghề", reportHeaderColumnFont));
                r3c7.BackgroundColor = green;
                r3c7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c7.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c7);

                PdfPCell r3c8 = new PdfPCell(new Phrase("Khu vực", reportHeaderColumnFont));
                r3c8.BackgroundColor = green;
                r3c8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c8.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c8);

                PdfPCell r3c9 = new PdfPCell(new Phrase("Chi nhánh", reportHeaderColumnFont));
                r3c9.BackgroundColor = green;
                r3c9.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c9.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c9);

                PdfPCell r3c10 = new PdfPCell(new Phrase("Cán bộ quản lý", reportHeaderColumnFont));
                r3c10.BackgroundColor = green;
                r3c10.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c10.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c10);

                PdfPCell r3c11 = new PdfPCell(new Phrase("Ngày lập báo cáo", reportHeaderColumnFont));
                r3c11.BackgroundColor = green;
                r3c11.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c11.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c11);

                PdfPCell r3c12 = new PdfPCell(new Phrase("Người lập báo cáo", reportHeaderColumnFont));
                r3c12.BackgroundColor = green;
                r3c12.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c12.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c12);

                PdfPCell r3c13 = new PdfPCell(new Phrase("Cấp cần báo cáo", reportHeaderColumnFont));
                r3c13.BackgroundColor = green;
                r3c13.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c13.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c13);

                PdfPCell r3c14 = new PdfPCell(new Phrase("Thành phần tham dự của khách hàng", reportHeaderColumnFont));
                r3c14.BackgroundColor = green;
                r3c14.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c14.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c14);

                PdfPCell r3c15 = new PdfPCell(new Phrase("Chủ đề gặp", reportHeaderColumnFont));
                r3c15.BackgroundColor = green;
                r3c15.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                r3c15.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(r3c15);

                // row 4
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);
                AddCellInternal(table, "Tổng hợp nội dung báo cáo trong ngày của công ty.", bodyFont);

                document.Add(table);

                document.Close();

                pdf = memoryStream.ToArray();
            }

            File.WriteAllBytes(MapPath("~/Uploads/a.pdf"), pdf);

            // Response.WriteFile(MapPath("~/Uploads/a.pdf"));
        }

        private PdfPCell AddCellInternal(PdfPTable table, string text = null, Font font = null, int colspan = 1, BaseColor bgColor = null)
        {
            PdfPCell cell;
            if (font == null)
            {
                cell = new PdfPCell(new Phrase(text));
            }
            else
            {
                cell = new PdfPCell(new Phrase(text, font));
            }

            if (colspan > 1)
            {
                cell.Colspan = colspan;
            }


            if (bgColor != null)
            {
                cell.BackgroundColor = bgColor;
            }

            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.PaddingBottom = 10f;
            table.AddCell(cell);

            return cell;
        }

        protected void ExportToPDF_OnClick1(object sender, EventArgs e)
        {
            //using (Stream stream = new FileStream("test.pdf", FileMode.CreateNew))
            //{
            //    //MemoryStream msOutput = new MemoryStream();
            //    TextReader reader = new StringReader(html);

            //    // step 1: creation of a document-object
            //    Document document = new Document(PageSize.A4, 30, 30, 30, 30);

            //    // step 2:
            //    // we create a writer that listens to the document
            //    // and directs a XML-stream to a file
            //    PdfWriter writer = PdfWriter.GetInstance(document, stream);

            //    // step 3: we create a worker parse the document
            //    HTMLWorker worker = new HTMLWorker(document);

            //    // step 4: we open document and start the worker on the document
            //    document.Open();
            //    worker.StartDocument();

            //    // step 5: parse the html into the document
            //    worker.Parse(reader);

            //    // step 6: close the document and the worker
            //    worker.EndDocument();
            //    worker.Close();
            //    document.Close();
            //}

            //return msOutput;
        }
    }
}