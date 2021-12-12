using Boomsa.WPF.BaseLib.ViewModel.Base;
using Boomsa.WPF.BaseLib.Infrastructure.Command;
using System.Windows.Input;
using Fitness.DAL.Entities;
using Fitness.DAL;
using Fitness.Interfaces;
using System.Windows.Controls;
using Fitness.WPF.NetCore.View.Windows;
using System;

namespace Fitness.WPF.NetCore.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IRepository<User> dbUsers;
        public MainViewModel(IRepository<User> _dbUsers)
        {
            dbUsers = _dbUsers;
        }
        public MainViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Использование конструктора для дизайн мода");
            
        }

        #region Commands


        #region Команда ChangeUser
        private ICommand _ChangeUserCommand;
        


        /// <summary>"Описание"</summary>
        public ICommand ChangeUserCommand =>
        _ChangeUserCommand ??=
        new LambdaCommand(OnChangeUserCommandExecuted, CanChangeUserCommandExecute);
        private void OnChangeUserCommandExecuted(object p)
        {
            var window = new CreateNewUserWindow();
            window.Show();
        }
        private bool CanChangeUserCommandExecute(object p) => true;     
        

        #endregion

        #endregion
    }
}
