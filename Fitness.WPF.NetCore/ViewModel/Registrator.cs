using Microsoft.Extensions.DependencyInjection;

namespace Fitness.WPF.NetCore.ViewModel
{
    internal static class Registrator

    {
        internal static IServiceCollection RegisterViewModels(this IServiceCollection services) => services
            .AddSingleton<MainViewModel>();


    }
}
