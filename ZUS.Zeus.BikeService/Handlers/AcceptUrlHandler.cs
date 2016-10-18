using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ZUS.Zeus.BikeService.Handlers
{
    public class AcceptUrlHandler : DelegatingHandler
    {
        private const string headerKey = "Accept";
        private const string formatParameter = "format";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var parameters = request.RequestUri.ParseQueryString();

            var format = parameters[formatParameter];

            if (format != null)
            {
                request.Headers.Remove(headerKey);
                request.Headers.Add(headerKey, format);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}