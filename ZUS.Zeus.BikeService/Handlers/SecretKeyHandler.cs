using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ZUS.Zeus.BikeService.Handlers
{
    public class SecretKeyHandler : DelegatingHandler
    {
        private const string _headerKey = "Secret-Key";
        private const string _secretKey = "12345";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (IsValid(request))
            {
                return await base.SendAsync(request, cancellationToken);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);

                return response;
            }

        }


        private bool IsValid(HttpRequestMessage request)
        {
            bool result = false;

            IEnumerable<string> secretKeys;

            if (request.Headers.TryGetValues(_headerKey, out secretKeys))
            {
                var secretKey = secretKeys.First();
                result = IsValidSecretKey(secretKey);
            }

            return result;
        }

        private static bool IsValidSecretKey(string secretKey)
        {
#if DEBUG
            return true;
#else

            return secretKey == _secretKey;
#endif
        }
    }
}