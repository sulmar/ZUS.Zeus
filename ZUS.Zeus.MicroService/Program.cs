using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using static System.Console;

namespace ZUS.Zeus.MicroService
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUri = "http://localhost:5001";

            WriteLine("Hello Micro Service");

            // Uruchomienie WebApi jako windows service 

            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<WebApiService>(sc =>
                {
                    sc.ConstructUsing(() => new WebApiService(baseUri));
                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.Stop());
                });

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.EnableShutdown();

                hostConfigurator.SetServiceName("MyMicroService");
                hostConfigurator.SetDisplayName("My micro service");
                hostConfigurator.SetDescription("Desciption micro service");

                hostConfigurator.StartAutomatically();
            });

            // Uruchomienie WebApi
            // WebApp.Start<Startup>(baseUri);

            WriteLine("Press any key to exit.");

            ReadKey();
        }
    }
}
