using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUS.Zeus.MicroService
{
    public class WebApiService
    {
        private readonly string baseAddress;

        private IDisposable _webapp;


        public WebApiService(string baseAddress)
        {
            this.baseAddress = baseAddress;
        }

        public void Start()
        {
            _webapp = WebApp.Start<Startup>(baseAddress);
        }

        public void Stop()
        {
            _webapp?.Dispose();
        }

    }
}
