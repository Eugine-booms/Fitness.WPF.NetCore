using Boomsa.WPF.BaseLib.ViewModel.Base;

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
        private readonly CreateNewUCViewModel newUserVM;
        private readonly CurentUserChangeViewModel changeUserVM;


        public CreateNewUserViewModel(CreateNewUCViewModel newUserVM)
        {
            this.newUserVM = newUserVM;
           // this.changeUserVM = changeUserVM;
            CurentModel = changeUserVM;
        }

        public CreateNewUserViewModel()
        {
        }

        #region  ViewModelBase CurentModel Текущая модель для представления
        ///<summary> Текущая модель для представления
        private ViewModelBase _CurentModel;
        ///<summary> Текущая модель для представления
        public ViewModelBase CurentModel
        {
            get => _CurentModel;
            set => Set(ref _CurentModel, value, nameof(CurentModel));
        }
        #endregion


    }
}
