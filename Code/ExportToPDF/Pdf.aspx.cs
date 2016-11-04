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

            ITable table = document.NewTable(2);

            ITableRow row1 = table.NewRow();
            row1.BackgoundColor = ReportColor.Red;
            row1.TextColor = ReportColor.While;

            ITableCell cell11 = row1.NewCell();
            cell11.Value = "Tiêu đề báo cáo";
            cell11.HorizontalAlignment = HorizontalAlignment.Center;
            cell11.Colspan = 2;

            ITableCell cell21 = row1.NewCell();
            cell21.Value = "Tiêu đề báo cáo 2";
            cell21.HorizontalAlignment = HorizontalAlignment.Left;


            ITableRow row2 = table.NewRow();

            ITableCell cell12 = row2.NewCell();
            cell12.Value = "Tiêu đề báo cáo dòng 2";
            cell12.HorizontalAlignment = HorizontalAlignment.Right;

            IParagraph p1 = new Paragraph("Hướng dẫn sử dụng thư viện xuất ra tệp PDF.");

            IText textBold = new Text(" Bold");
            textBold.Style = FontStyle.Bold;
            p1.AddText(textBold);

            document.AddElement(p1);

            IParagraph p2 = new Paragraph("Hướng dẫn sử dụng thư viện xuất ra tệp PDF.");
            p2.PaddingBottom = 10f;

            IText textBold2 = new Text(" Bold");
            textBold2.Style = FontStyle.Bold;
            p2.AddText(textBold);

            document.AddElement(p2);

            document.InsertFromExcel(MapPath("~/Uploads/data_empty.xlsx"));
            document.InsertFromExcel(MapPath("~/Uploads/data.xlsx"));

            document.Save(MapPath("~/Uploads/b.pdf"));
        }

        protected void ExportToPdfMergeRowButton_Click(object sender, EventArgs e)
        {
            ReportFactory.SetStyle1ForPDF();
            PdfDocument document = new PdfDocument(PageSize.A4);
            document.PageOrientation = PageOrientation.Landscape;

            ITable table = document.NewTable(3);
            ITableRow row1 = table.NewRow();
            row1.BackgoundColor = ReportColor.Red;
            row1.TextColor = ReportColor.While;

            ITableCell r1c123 = row1.NewCell();
            r1c123.Value = "R1C1 - R2C1 - R3C1";
            r1c123.HorizontalAlignment = HorizontalAlignment.Center;
            r1c123.VerticalAlignment = VerticalAlignment.Middle;
            r1c123.Rowspan = 3;

            ITableCell r1c2 = row1.NewCell();
            r1c2.Value = "R1C2";

            ITableCell r1c3 = row1.NewCell();
            r1c3.Value = "R1C3";


            ITableRow row2 = table.NewRow();

            ITableCell r2c2 = row2.NewCell();
            r2c2.Value = "R2C2";

            ITableCell r2c3 = row2.NewCell();
            r2c3.Value = "R2C3";


            ITableRow row3 = table.NewRow();

            ITableCell r3c2 = row3.NewCell();
            r3c2.Value = "R3C2";

            ITableCell r3c3 = row3.NewCell();
            r3c3.Value = "R3C3";


            // document.InsertFromExcel(MapPath("~/Uploads/data_merge_row.xlsx"));

            document.Save(MapPath("~/Uploads/data_merge_row.pdf"));
        }
    }
}