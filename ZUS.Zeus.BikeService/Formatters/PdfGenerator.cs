using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ZUS.Zeus.Models;

namespace ZUS.Zeus.BikeService.Formatters
{
    public class PdfGenerator
    {
        public MemoryStream Generate(Bike bike)
        {
            var document = new Document();

            var section = document.Sections.AddSection();

            section.AddParagraph(bike.Number);

            var renderer = new PdfDocumentRenderer { Document = document };

            renderer.RenderDocument();

            var stream = new MemoryStream();

            renderer.PdfDocument.Save(stream);

            return stream;
        }
    }
}