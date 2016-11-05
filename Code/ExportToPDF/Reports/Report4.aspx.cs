using Klat.ReportIO;
using Klat.ReportIO.Enums;
using Klat.ReportIO.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Klat.Example.Reports
{
    public partial class Report4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExportToPdfMergeRowButton_Click(object sender, EventArgs e)
        {
            ReportFactory.SetStyle1ForPDF();
            PdfDocument document = new PdfDocument(PageSize.A0);
            document.PageOrientation = PageOrientation.Landscape;

            document.InsertFromExcel(MapPath("~/Uploads/Report_4_TongHopCallReport.xlsx"));

            ReportColor green = ReportColor.Create(0, 100, 45);
            ReportColor textHong = ReportColor.Create(230, 184, 183);
            ReportColor textKhds = ReportColor.Create(99, 37, 35);
            ReportColor textKhln = ReportColor.Create(118, 147, 60);
            ReportColor textThds = ReportColor.Create(96, 73, 122);
            ReportColor textThln = ReportColor.Create(49, 134, 155);

            document.Save(MapPath("~/Uploads/Report_4_TongHopCallReport.pdf"), (paragraphs) =>
            {
                foreach (IElementRoot paragraph in paragraphs)
                {
                    if (paragraph is ITable)
                    {
                        ITable table = paragraph as ITable;
                        ITableRow row1 = table.Rows[0];

                        for (int i = 1; i <= row1.Cells.Count; i++)
                        {
                            ITableCell cell = row1.Cells[i - 1];
                            cell.BackgoundColor = green;

                            if (i > 3)
                            {
                                cell.TextColor = textHong;
                            }
                            else
                            {
                                cell.TextColor = ReportColor.While;
                            }
                        }

                        ITableRow row3 = table.Rows[2];
                        for (int i = 1; i <= row3.Cells.Count; i++)
                        {
                            ITableCell cell = row3.Cells[i - 1];
                            cell.TextColor = ReportColor.While;
                            cell.BackgoundColor = green;
                        }
                    }
                }

                return paragraphs;
            });
        }
    }
}