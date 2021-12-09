using Boomsa.WPF.BaseLib.Services;
using Boomsa.WPF.BaseLib.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Fitness.WPF.NetCore.Services
{
    internal static class Registrator
    {
        internal static IServiceCollection RegisterServices(this IServiceCollection services) => services
            .AddTransient<IUserDialog, UserDialog>();

    }
}
