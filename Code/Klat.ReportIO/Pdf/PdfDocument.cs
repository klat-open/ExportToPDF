using Klat.ReportIO.Commons;
using Klat.ReportIO.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public static implicit operator iTextSharp.text.Document(PdfDocument pdfDocument)
        {
            PageSize currentPageSize = pdfDocument.PageSize ?? ReportFactory.PageSize;
            iTextSharp.text.Rectangle pageSize = PageSizeUtils.ToRectangle(currentPageSize);
            var document = new iTextSharp.text.Document(pageSize, 10, 10, 10, 10);

            return document;
        }

        public void Save(string fileName)
        {

        }
    }
}
