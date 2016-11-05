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
    public partial class Report1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExportToPdfMergeRowButton_Click(object sender, EventArgs e)
        {
            ReportFactory.SetStyle1ForPDF();
            PdfDocument document = new PdfDocument(PageSize.A0);
            document.PageOrientation = PageOrientation.Landscape;
            
            document.InsertFromExcel(MapPath("~/Uploads/Report_1_ThucHienAP.xlsx"));

            ReportColor green = ReportColor.Create(0, 100, 45);
            ReportColor textHong = ReportColor.Create(230, 184, 183);
            ReportColor textKhds = ReportColor.Create(99, 37, 35);
            ReportColor textKhln = ReportColor.Create(118, 147, 60);
            ReportColor textThds = ReportColor.Create(96, 73, 122);
            ReportColor textThln = ReportColor.Create(49, 134, 155);

            document.Save(MapPath("~/Uploads/Report_1_ThucHienAP.pdf"), (paragraphs) =>
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

                            if (i >= 3)
                            {
                                cell.TextColor = textHong;
                            }
                            else
                            {
                                cell.TextColor = ReportColor.While;
                            }
                        }

                        ITableRow row4 = table.Rows[3];
                        for (int i = 1; i <= row4.Cells.Count; i++)
                        {
                            ITableCell cell = row4.Cells[i - 1];
                            cell.TextColor = ReportColor.While;
                            if (i <= 10)
                            {
                                cell.BackgoundColor = green;
                            }
                            else if (i == 11)
                            {
                                cell.BackgoundColor = textKhds;
                            }
                            else if (i == 12)
                            {
                                cell.BackgoundColor = textKhln;
                            }
                            else if (i == 13)
                            {
                                cell.BackgoundColor = textThds;
                            }
                            else if (i == 14)
                            {
                                cell.BackgoundColor = textThln;
                            }
                        }

                        ITableRow row5 = table.Rows[4];
                        for (int i = 1; i <= row5.Cells.Count; i++)
                        {
                            ITableCell cell = row5.Cells[i - 1];
                            cell.TextColor = ReportColor.While;

                            if (i <= 11)
                            {
                                cell.BackgoundColor = textKhds;
                            }
                            else if (i <= 18)
                            {
                                cell.BackgoundColor = textKhln;
                            }
                            else if (i <= 29)
                            {
                                cell.BackgoundColor = textThds;
                            }
                            else
                            {
                                cell.BackgoundColor = textThln;
                            }
                        }
                    }
                }

                return paragraphs;
            });
        }
    }
}