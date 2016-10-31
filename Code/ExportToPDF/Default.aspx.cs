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

namespace ExportToPDF
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExportToPDF_OnClick(object sender, EventArgs e)
        {
            byte[] pdf; // result will be here

            var cssText = File.ReadAllText(MapPath("~/Content/bootstrap.css"));
            var html = File.ReadAllText(MapPath("~/Uploads/a.htm"));

            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 50, 50, 60, 60);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText)))
                {
                    using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, cssMemoryStream);
                    }
                }

                document.Close();

                pdf = memoryStream.ToArray();
            }

            File.WriteAllBytes(MapPath("~/Uploads/a.pdf"), pdf);

            // Response.WriteFile(MapPath("~/Uploads/a.pdf"));
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