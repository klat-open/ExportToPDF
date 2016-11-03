using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public int? MarginTop { get; set; }

        public int? MarginRight { get; set; }

        public int? MarginBottom { get; set; }

        public int? MarginLeft { get; set; }

        public ArrayList Paragraphs = new ArrayList();

        public void AddParagraph(Table table)
        {
            Paragraphs.Add(table);
        }

        public Table NewTable(int columLength)
        {
            Table table = Table.Create(columLength);
            Paragraphs.Add(table);

            return table;
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
