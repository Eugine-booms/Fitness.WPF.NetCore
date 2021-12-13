using Microsoft.Extensions.DependencyInjection;

namespace Fitness.WPF.NetCore.ViewModel
{
    internal class Locator
    {
        public MainViewModel GetMainVM => App.Services.GetRequiredService<MainViewModel>();
        public CreateNewUserViewModel GetCreateuserVM => App.Services.GetRequiredService<CreateNewUserViewModel>();

    }
}
