using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.DAL.Entities;
using Fitness.WPF.NetCore.Services;
using Fitness.WPF.NetCore.Services.Interfaces;
using Fitness.WPF.NetCore.View.UserControls;
using Fitness.WPF.NetCore.ViewModel.UCViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fitness.WPF.NetCore.ViewModel
{
    public class PageSwitcherVM : ViewModelBase , ISwitcher
    {
        protected User CurrentUser;
        private ContentControl _Contentcontrol;
        public ContentControl Contentcontrol => _Contentcontrol ??= new ContentControl();
        public User  User {get => CurrentUser; set => CurrentUser=value;}

        public PageSwitcherVM(User user)
        {
            CurrentUser = user;
            Switcher.pageSwitcher = this;
            Switcher.Switch(new ChangeUserUCVM(user));
        }

        public void Navigate(ViewModelBase nextPage)
        {
            Contentcontrol.Content= nextPage;
            OnPropertyChanged("Contentcontrol");
        }
    }
}
