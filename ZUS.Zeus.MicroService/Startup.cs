using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ZUS.Zeus.MicroService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            using (var config = new HttpConfiguration())
            {
                WebApiConfig.Register(config);

                appBuilder.UseWebApi(config);
            }
        }
    }
}
