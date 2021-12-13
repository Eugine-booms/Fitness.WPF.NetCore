using Boomsa.WPF.BaseLib.Infrastructure.Command;
using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.DAL.Entities;
using Fitness.Interfaces;
using Fitness.WPF.NetCore.Services;
using Fitness.WPF.NetCore.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Windows.Input;

namespace Fitness.WPF.NetCore.ViewModel.UCViewModel
{
    public class CreateNewUCVM : ViewModelBase, ISwitchable
    {
        private IRepository<User> _usersRepository { get; }

        #region  User Пользователь для редактирования
        ///<summary> Пользователь для редактирования
        private User _User;
        ///<summary> Пользователь для редактирования
        public User User
        {
            get => _User;
            set => Set(ref _User, value, nameof(User));
        }
        #endregion

        #region  string Password ""
        ///<summary> ""
        private string _Password;
        ///<summary> ""
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value, nameof(Password));
        }
        #endregion


        public CreateNewUCVM()
        {
            _usersRepository = App.Services.GetRequiredService<IRepository<User>>();
            //if (!App.IsDesignTime)
            //    throw new InvalidOperationException("Использование конструктора для дизайн мода");
        }



        #region Команда BackToUserLogin
        private ICommand _BackToUserLoginCommand;
        /// <summary>"Описание"</summary>
        public ICommand BackToUserLoginCommand =>
        _BackToUserLoginCommand ??=
        new LambdaCommand(OnBackToUserLoginCommandExecuted, CanBackToUserLoginCommandExecute);
        private void OnBackToUserLoginCommandExecuted(object p)
        {
            Switcher.Switch(new ChangeUserUCVM(Switcher.pageSwitcher.User));
        }
        private bool CanBackToUserLoginCommandExecute(object p) => true;
        #endregion
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
