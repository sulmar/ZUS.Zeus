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

    public class GoogleQrCodeFormatter : MediaTypeFormatter
    {
        private const string supportedMediaType = "image/png";

        public GoogleQrCodeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(supportedMediaType));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Bike);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {

            var bike = value as Bike;

            var number = HttpUtility.UrlEncode(bike.Number);

            var uri = $"http://chart.apis.google.com/chart?cht=qr&chs=300x300&chl={number}";

            using (var client = new WebClient())
            {
                var data = await client.DownloadDataTaskAsync(uri);

                writeStream.Write(data, 0, data.Length);
            }


        }
    }
}