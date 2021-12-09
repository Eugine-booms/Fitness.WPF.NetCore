using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore
{
    class Program
    {

        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();


        }

        internal static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(App.ConfigureServices)
            .ConfigureHostConfiguration(config=>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables("PREFIX_")
                .AddCommandLine(args)
                .AddJsonFile("appsettings.json", true);
            });
        
    }
}
