using Fitness.DAL.Entities;
using Fitness.WPF.NetCore.Services.Interfaces;
using Fitness.WPF.NetCore.View.UserControls;
using Fitness.WPF.NetCore.View.Windows;
using Fitness.WPF.NetCore.ViewModel;
using Fitness.WPF.NetCore.ViewModel.UCViewModel;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fitness.WPF.NetCore.Services
{
    class ChangeUserDialog : IChangeUserDialog
    {
        public User ChangeUser(User currentUser=null)
        {
            User current=currentUser??new User();
            var changeUserVM = new PageSwitcherVM(current);
            var changeUserWindow = new PageSwitcher
            {
                DataContext = changeUserVM,
                Title = "Смена пользователя",
                Owner = App.CurrentWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (changeUserWindow.ShowDialog()!=true) 
            {
                return currentUser;
            }
                                   




            return current;
        }
    }
}
