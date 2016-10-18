using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using ZUS.Zeus.Models;

namespace ZUS.Zeus.BikeService.Formatters
{
    public class PdfFormatter : MediaTypeFormatter
    {
        private const string supportedMediaType = "application/pdf";

        public PdfFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(supportedMediaType));
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var bike = value as Bike;

            var generator = new PdfGenerator();

            using (var stream = generator.Generate(bike))
            {
                var bytes = stream.ToArray();
                return writeStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Bike);
        }
    }
}