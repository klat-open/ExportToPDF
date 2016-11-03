using Klat.ReportIO.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klat.ReportIO.Commons
{
    public static class FontUtils
    {
        public static string GetFontPath(FontList font, FontStyle style)
        {
            if (font == FontList.TimesNewRoman)
            {
                if (style == FontStyle.Bold)
                {
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "timesbd.ttf");
                }
                else if (style == FontStyle.Italic)
                {
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "timesi.ttf");
                }
                else if (style == FontStyle.BoldItalic)
                {
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "timesbi.ttf");
                }

                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
            }

            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
        }
    }
}
