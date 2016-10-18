using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using FluentValidation.WebApi;
using ZUS.Zeus.BikeService.Handlers;
using ZUS.Zeus.BikeService.Formatters;
using ZUS.Zeus.BikeService.Filters;

namespace ZUS.Zeus.BikeService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.MessageHandlers.Add(new TraceMessageHandler());
            //  config.MessageHandlers.Add(new SecretKeyHandler());
            config.MessageHandlers.Add(new AcceptUrlHandler());

            // config.Formatters.Add(new GoogleQrCodeFormatter());

            config.Formatters.Add(new QrCodeFormatter());
            config.Formatters.Add(new PdfFormatter());


            config.Filters.Add(new ValidateModelStateAttribute());
            config.Filters.Add(new ExecutionTimeFilterAttribute());

            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
