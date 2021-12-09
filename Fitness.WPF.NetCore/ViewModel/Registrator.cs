using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.ViewModel
{
  static internal  class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services) => services
            .AddSingleton<MainViewModel>();
    }
}
