using Klat.ReportIO;
using Klat.ReportIO.Enums;
using Klat.ReportIO.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Klat.Example
{
    public partial class Pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExportToPdfButton_Click(object sender, EventArgs e)
        {
            ReportFactory.SetStyle1ForPDF();
            PdfDocument document = new PdfDocument(PageSize.A4);
            document.PageOrientation = PageOrientation.Landscape;

            Table table = document.NewTable(2);

            TableRow row1 = table.NewRow();
            row1.BackgoundColor = ReportColor.Red;
            row1.TextColor = ReportColor.While;

            TableCell cell11 = row1.NewCell();
            cell11.Value = "Tiêu đề báo cáo";
            cell11.HorizontalAlignment = HorizontalAlignment.Center;


            TableRow row2 = table.NewRow();

            TableCell cell12 = row2.NewCell();
            cell12.Value = "Tiêu đề báo cáo dòng 2";
            cell12.HorizontalAlignment = HorizontalAlignment.Right;

            Paragraph p1 = new Paragraph("Hướng dẫn sử dụng thư viện xuất ra tệp PDF.");

            Text textBold = new Text(" Bold");
            textBold.Style = FontStyle.Bold;
            p1.AddText(textBold);

            document.AddParagraph(p1);

            document.Save(MapPath("~/Uploads/b.pdf"));
        }
    }
}