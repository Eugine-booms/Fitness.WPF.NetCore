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
            var changeUserWindow = new CreateNewUserWindow();

            
            //var changeUserUCVM = App.Services.GetRequiredService<ChangeUserUCVM>();
            //var createUserUCVM = App.Services.GetRequiredService<CreateNewUCVM>();
            changeUserUCVM.CurentUser = current;
            //var changeUserVM = new CreateNewUserViewModel(createUserUCVM, changeUserUCVM);
            //changeUserWindow.DataContext = changeUserVM;
            changeUserWindow.Title = "Смена пользователя";
            changeUserWindow.Owner = App.CurrentWindow;
            changeUserWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                
            if (changeUserWindow.ShowDialog()!=true) 
            {
                return currentUser;
            }
                                   




            return current;
        }
    }
}
