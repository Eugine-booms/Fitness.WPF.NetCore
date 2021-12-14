using Boomsa.WPF.BaseLib.Infrastructure.Command;
using Boomsa.WPF.BaseLib.Services.Interfaces;
using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.DAL;
using Fitness.DAL.Entities;
using Fitness.Interfaces;
using Fitness.WPF.NetCore.Services;
using Fitness.WPF.NetCore.Services.Interfaces;
using Fitness.WPF.NetCore.View.UserControls;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Fitness.WPF.NetCore.ViewModel.UCViewModel
{
    public class ChangeUserUCVM : ViewModelBase, ISwitchable
    {
        private readonly IRepository<User> _dbUsers;
        private readonly IUserDialog _userDialog;
        private readonly CollectionViewSource UsersView = new CollectionViewSource();
        public ICollectionView Users => UsersView?.View;

        #region User Старый пользователь, до смены если есть
        private User _OldUser;
        public User OldUser
        {
            get => _OldUser;
            set => Set(ref _OldUser, value);
        } 
        #endregion

        #region  string  TextBoxPassword
        ///<summary> Строка пароля

        private string _TextBoxPassword;
        ///<summary> ""
        public string TextBoxPassword
        {
            get => _TextBoxPassword;
            set => Set(ref _TextBoxPassword, value, nameof(TextBoxPassword));
        }
        #endregion

        #region User Выбранный пользователь
        private User _CurrentUser;
        public User CurrentUser
        {
            get => _CurrentUser;
            set
            {
                if (!Set(ref _CurrentUser, value)) return;

                if (value != null)
                {
                    TextBoxLogin = value.Name;
                }
            }
        }
        #endregion

        #region String Login
        private string _textBoxLogin;
        public string TextBoxLogin
        {
            get => _textBoxLogin;
            set
            {
                if (!Set(ref _textBoxLogin, value)) return;
                var su = CurrentUser;      //Без этого не работает, приходится кликать 2 раза.
                Users.Refresh();
                CurrentUser = su;
            }
        }
        #endregion


        public ChangeUserUCVM()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Использование конструктора для дизайн мода");
        }

        #region Конструктор

        public ChangeUserUCVM(User user)
        {
            OldUser = user;

            _dbUsers = App.Services.GetRequiredService<IRepository<User>>();
            _userDialog = App.Services.GetRequiredService<IUserDialog>();
            UsersView.Source = _dbUsers.Items;
            OnPropertyChanged(nameof(Users));
            UsersView.Filter += UsersView_Filter;
        } 
        #endregion

        private void UsersView_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = (e.Item as User)?.Name?.ToLower().Contains(_textBoxLogin?.ToLower() ?? "") ?? true;
        }

        #region Команды
        #region Создание нового пользователя
        private ICommand _NewUserCommand;
        /// <summary>"Описание"</summary>
        public ICommand NewUserCommand =>
        _NewUserCommand ??= new LambdaCommand(OnNewUserCommandExecuted, CanNewUserCommandExecute);
        private void OnNewUserCommandExecuted(object p)
        {
            Switcher.Switch(new CreateNewUCVM());
        } 

        private bool CanNewUserCommandExecute(object p) => true;
        #endregion

        #region Вход попользователя
        private ICommand _ChangeUserCommand;
        /// <summary>"Описание"</summary>
        public ICommand ChangeUserCommand =>
        _ChangeUserCommand ??=
        new LambdaCommand(OnChangeUserCommandExecuted, CanChangeUserCommandExecute);

        private void OnChangeUserCommandExecuted(object p)
        {
            if (CurrentUser.Password != TextBoxPassword)
            {
                _userDialog.Error_OK("Ошибка", "Не верный пароль");
                return;
            }
            var window = App.CurrentWindow;
            if (p != null)
            {
                ((PageSwitcherVM)Switcher.pageSwitcher).User = CurrentUser;
                window.DialogResult = (bool?)Convert.ChangeType(p, typeof(bool));
            }

        }
        private bool CanChangeUserCommandExecute(object p) => CurrentUser != null; 
        #endregion
        #endregion

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
