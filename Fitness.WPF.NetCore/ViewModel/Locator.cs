using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.ViewModel
{
    public class Locator
    {
        public  MainViewModel GetMainVM => App.Services.GetRequiredService<MainViewModel>();
    }
}
