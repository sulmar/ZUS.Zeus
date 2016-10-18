using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ZUS.Zeus.BikeService.Handlers
{
    public class TraceMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            Debug.WriteLine($"{request.Method.Method}: {request.RequestUri}");
            var content = await request.Content.ReadAsStringAsync();

            Debug.WriteLine(content);

            var response = await base.SendAsync(request, cancellationToken);

            response.Headers.Add("SecretKey", "Vavatech");

            return response;



        }
    }
}