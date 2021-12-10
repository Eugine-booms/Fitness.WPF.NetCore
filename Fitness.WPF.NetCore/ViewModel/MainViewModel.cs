using Boomsa.WPF.BaseLib.ViewModel.Base;
using Boomsa.WPF.BaseLib.Infrastructure.Command;
using System.Windows.Input;

namespace Fitness.WPF.NetCore.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
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

        }
        private bool CanChangeUserCommandExecute(object p) => true;     
        

        #endregion

        #endregion
    }
}
