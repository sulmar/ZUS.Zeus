using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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


    public class QrCodeFormatter : MediaTypeFormatter
    {
        private const string supportedMediaType = "image/png";

        public QrCodeFormatter()
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

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var bike = value as Bike;

            var number = HttpUtility.UrlEncode(bike.Number);

            var qrCodeImage = CreateQrCode(number);

            using (var stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, ImageFormat.Png);
                var data = stream.ToArray();

                return writeStream.WriteAsync(data, 0, data.Length);
            }
        }

        /// <summary>
        /// Install-Package QRCoder
        /// </summary>
        private static Bitmap CreateQrCode(string number)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(number, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}