using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ZUS.Zeus.BikeService.Tests
{

    [TestClass]
    public class MyIntegrationTests
    {
        [TestMethod]
        public async Task InMemoryTest()
        {
            using (var server = TestServer.Create(app =>
            {
                var config = new HttpConfiguration();
                config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
                app.UseWebApi(config);
            }))
            {
                var response = await server.HttpClient.GetAsync("api/bikes/1");

                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

                var body = await response.Content.ReadAsStringAsync();

                Assert.IsTrue(body.Contains("\"BikeId\":1"));

            }
        }


    }
}