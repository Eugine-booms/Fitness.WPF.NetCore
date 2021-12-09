using Boomsa.WPF.BaseLib.Services;
using Boomsa.WPF.BaseLib.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.Services
{
  static internal  class Registrator
    {
        internal static IServiceCollection RegisterServices(this IServiceCollection services) => services
            .AddTransient<IUserDialog, UserDialog>();
           
    }
}
