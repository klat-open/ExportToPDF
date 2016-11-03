using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Commons
{
    public static class PageSizeUtils
    {
        public static iTextSharp.text.Rectangle ToRectangle(this PageSize pageSizeSource, PageOrientation orientation = PageOrientation.Portrait)
        {
            iTextSharp.text.Rectangle pageSize;
            switch (pageSizeSource)
            {
                case PageSize.A0:
                    pageSize = iTextSharp.text.PageSize.A0;
                    break;
                case PageSize.A1:
                    pageSize = iTextSharp.text.PageSize.A1;
                    break;
                case PageSize.A2:
                    pageSize = iTextSharp.text.PageSize.A2;
                    break;
                case PageSize.A3:
                    pageSize = iTextSharp.text.PageSize.A3;
                    break;
                case PageSize.A4:
                    pageSize = iTextSharp.text.PageSize.A4;
                    break;
                default:
                    pageSize = iTextSharp.text.PageSize.A4;
                    break;
            }

            if (orientation == PageOrientation.Landscape)
            {
                pageSize = pageSize.Rotate();
            }

            return pageSize;
        }
    }
}
