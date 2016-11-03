using Klat.ReportIO.Enums;

namespace Klat.ReportIO.Commons
{
    public static class PageSizeUtils
    {
        public static iTextSharp.text.Rectangle ToRectangle(PageSize pageSize)
        {
            switch (pageSize)
            {
                case PageSize.A0:
                    return iTextSharp.text.PageSize.A0;
                case PageSize.A1:
                    return iTextSharp.text.PageSize.A1;
                case PageSize.A2:
                    return iTextSharp.text.PageSize.A2;
                case PageSize.A3:
                    return iTextSharp.text.PageSize.A3;
                case PageSize.A4:
                    return iTextSharp.text.PageSize.A4;
                default:
                    return iTextSharp.text.PageSize.A4;
            }
        }
    }
}
