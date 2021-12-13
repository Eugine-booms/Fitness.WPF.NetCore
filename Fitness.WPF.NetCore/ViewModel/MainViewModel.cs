using Boomsa.WPF.BaseLib.ViewModel.Base;
using Boomsa.WPF.BaseLib.Infrastructure.Command;
using System.Windows.Input;
using Fitness.DAL.Entities;
using Fitness.Interfaces;
using System;
using Fitness.WPF.NetCore.Services.Interfaces;

namespace Fitness.WPF.NetCore.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly IRepository<User> _dbUsers;
        private readonly IChangeUserDialog _changeUserDialog;


        #region  User CurrentUser Текущий пользователь
        ///<summary> Текущий пользователь
        private User _CurrentUser;
        ///<summary> Текущий пользователь
        public User CurrentUser
        {
            get => _CurrentUser;
            set => Set(ref _CurrentUser, value, nameof(CurrentUser));
        }
        #endregion


        public MainViewModel(IRepository<User> dbUsers, IChangeUserDialog changeUserDialog)
        {
            _dbUsers = dbUsers;
            _changeUserDialog = changeUserDialog;
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
            _changeUserDialog.ChangeUser(CurrentUser);     
        }
        private bool CanChangeUserCommandExecute(object p) => true;     
        

        #endregion

        #endregion
    }
}
