using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.DAL.Entities;
using Fitness.WPF.NetCore.ViewModel.UCViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.ViewModel
{
  public  class CreateNewUserViewModel : ViewModelBase
    {
        private readonly CreateNewUCVM newUserVM;
        private readonly ChangeUserUCVM changeUserVM;
        protected User CurrentUser;


        public CreateNewUserViewModel(CreateNewUCVM newUserVM, ChangeUserUCVM changeUserVM )
        {
            this.newUserVM = newUserVM;
            newUserVM.ParentVM = this;
            this.changeUserVM = changeUserVM;
            changeUserVM.ParentVM = this;
            CurrentModel = changeUserVM;
        }

        //public CreateNewUserViewModel() : this (new CreateNewUCVM(), new ChangeUserUCVM())
        //{
        //    if (!App.IsDesignTime)
        //        throw new InvalidOperationException("Использование конструктора для дизайн мода");
        //}

        #region  ViewModelBase CurentModel Текущая модель для представления
        ///<summary> Текущая модель для представления
        private ViewModelBase _CurentModel;
        ///<summary> Текущая модель для представления
        public ViewModelBase CurrentModel
        {
            get => _CurentModel;
            set => Set(ref _CurentModel, value, nameof(CurrentModel));
        }

        internal void ChangeCurrentVMToNewUser()
        {
            CurrentModel = newUserVM;
        }
        #endregion


    }
}
