using Boomsa.WPF.BaseLib.ViewModel.Base;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.ViewModel.UCViewModel
{
    internal class CreateNewUserViewModel : ViewModelBase
    {
        private User user;

        public CreateNewUserViewModel()
        {
            user = new User();
        }
        public void SetUserName(string Name)
        {
            user.Name = Name;
        }

    }
}
