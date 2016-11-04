using Klat.ReportIO.Enums;
using System;
using System.Collections.Generic;

namespace Klat.ReportIO.Pdf
{
    public interface IPdfDocument
    {
        PageSize? PageSize { get; set; }

        PageOrientation? PageOrientation { get; set; }

        float? MarginTop { get; set; }

        float? MarginRight { get; set; }

        float? MarginBottom { get; set; }

        float? MarginLeft { get; set; }

        List<IElementRoot> Paragraphs { get; set; }

        void AddElement(IElementRoot element);

        void AddElements(params IElementRoot[] elements);

        Table NewTable(int columLength);

        /// <summary>
        /// Hỗ trợ định dạng mới của excel (*.xlsx).
        /// </summary>
        /// <param name="fileName"></param>
        void InsertFromExcel(string fileName);

        void Save(string fileName, Func<List<IElementRoot>, List<IElementRoot>> formatFunc = null);
        
        void SaveByMemoryStream(string fileName);
    }
}
