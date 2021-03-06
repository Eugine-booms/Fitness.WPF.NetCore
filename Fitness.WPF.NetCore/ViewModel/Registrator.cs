using Fitness.WPF.NetCore.ViewModel.UCViewModel;

using Microsoft.Extensions.DependencyInjection;

namespace Fitness.WPF.NetCore.ViewModel
{
    internal static class Registrator

    {
        internal static IServiceCollection RegisterViewModels(this IServiceCollection services) => services
            .AddTransient<MainViewModel>()
            .AddTransient<PageSwitcherVM>()
            .AddTransient<CreateNewUCVM>()
            .AddTransient< ChangeUserUCVM>();


    }
}
