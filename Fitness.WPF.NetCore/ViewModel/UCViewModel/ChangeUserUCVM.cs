using Boomsa.WPF.BaseLib.Infrastructure.Command;
using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.DAL;
using Fitness.DAL.Entities;
using Fitness.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Fitness.WPF.NetCore.ViewModel.UCViewModel
{
    public class ChangeUserUCVM : ViewModelBase
{
        private readonly IRepository<User> _dbUsers;
        internal CreateNewUserViewModel ParentVM;




        #region Property Переменные
        private ICollectionView _users;
        public ICollectionView Users
        {
            get => _users;
            set => Set(ref _users, value);
        }


        private string _textBoxLogin;
        public string TextBoxLogin
        {
            get => _textBoxLogin;
            set => Set(ref _textBoxLogin, value);
        }

        private User _curentUser;
        
        public User CurentUser
        {
            get => _curentUser;
            set => Set(ref _curentUser, value);
        }
        //public CurentUserChangeViewModel()
        //{
        //    if (!App.IsDesignTime)
        //        throw new InvalidOperationException("Использование конструктора для дизайн мода");
        //}
        #endregion


        #region Конструктор

        public ChangeUserUCVM(IRepository<User> user)
        {

            _dbUsers = user;
            Users = CollectionViewSource.GetDefaultView(_dbUsers.Items);
            CurentUser=ParentVM.

        }

        #endregion



        #region Команда NewUser
        private ICommand _NewUserCommand;
        /// <summary>"Описание"</summary>
        public ICommand NewUserCommand =>
        _NewUserCommand ??=
        new LambdaCommand(OnNewUserCommandExecuted, CanNewUserCommandExecute);
        private void OnNewUserCommandExecuted(object p)
        {
            ParentVM.ChangeCurrentVMToNewUser();
        }
        private bool CanNewUserCommandExecute(object p) => true;

        #endregion

        #region Команда ChangeUser
        private ICommand _ChangeUserCommand;
        /// <summary>"Описание"</summary>
        public ICommand ChangeUserCommand =>
        _ChangeUserCommand ??=
        new LambdaCommand(OnChangeUserCommandExecuted, CanChangeUserCommandExecute);

     

        private void OnChangeUserCommandExecuted(object p)
        {
            
        }
        private bool CanChangeUserCommandExecute(object p) => CurentUser != null;

        #endregion

    }
}
