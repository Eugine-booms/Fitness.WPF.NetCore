using Fitness.WPF.NetCore.Services;
using Fitness.WPF.NetCore.ViewModel;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fitness.WPF.NetCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesignTime { get; private set; } = true;
        public static Window ActiveWindow => App.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive == true);
        public static Window FocusedWindow => App.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsFocused == true);
        public static Window CurrentWindow => FocusedWindow ?? ActiveWindow; 

        private static IHost _host;
        public static IHost Host => _host ??= _host = Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) =>
           services
            .RegisterViewModels()
            .RegisterServices();

           //.RegisterDataBase(host.Configuration.GetSection("Database"))
           //.RegisterRepositoryesInDB();
        public static IServiceProvider Services => Host.Services;
        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignTime = false;
            var host = Host;
            await host.RunAsync().ConfigureAwait(false);
            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            var host = Host;
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
            }
            base.OnExit(e);
            host = null;
        }
    }
       
}
