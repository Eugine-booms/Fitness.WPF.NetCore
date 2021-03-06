using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Configuration;
using System.IO;

namespace Fitness.WPF.NetCore
{
    internal class Program
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
            .ConfigureLogging(logging =>
            {
                
                logging.AddJsonConsole() ;
                
            })
            .ConfigureHostConfiguration(config =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables("PREFIX_")
                .AddCommandLine(args)
                .AddJsonFile("appsettings.json", true);
            })
            
            ;

    }
}
