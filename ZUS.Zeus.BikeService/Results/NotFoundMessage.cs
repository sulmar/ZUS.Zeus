using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ZUS.Zeus.BikeService.Results
{

    public static class ApiControllerExtensions
    {
        public static IHttpActionResult NotFound(this ApiController controller, string content)
        {
            return new NotFoundResult(content);
        }
    }

    public class NotFoundResult : IHttpActionResult
    {
        private readonly string _content;

        public NotFoundResult(string content)
        {
            _content = content;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
            {
                Content = new StringContent(_content.ToString())
            };

            return Task.FromResult(response);
        }
    }
}