using Microsoft.Extensions.DependencyInjection;

namespace Fitness.WPF.NetCore.ViewModel
{
    internal class Locator
    {
        public MainViewModel GetMainVM => App.Services.GetRequiredService<MainViewModel>();
        public PageSwitcherVM GetCreateuserVM => App.Services.GetRequiredService<PageSwitcherVM>();

    }
}
