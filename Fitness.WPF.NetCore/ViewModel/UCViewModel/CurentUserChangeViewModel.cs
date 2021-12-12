using Boomsa.WPF.BaseLib.Infrastructure.Command;
using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.DAL;
using Fitness.DAL.Entities;
using Fitness.Interfaces;

using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Fitness.WPF.NetCore.ViewModel.UCViewModel
{
    public class CurentUserChangeViewModel : ViewModelBase
{
        private readonly IRepository<User> _dbUsers;
        private readonly ViewModelBase _parentVM;

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

        #endregion
        public CurentUserChangeViewModel()
        {
            //_parentVM = parentVM;
            //_dbUsers = users;
            //Users = CollectionViewSource.GetDefaultView(_dbUsers.Items);
        }
    }
}
