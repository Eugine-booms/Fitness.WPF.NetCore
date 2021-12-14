using Boomsa.WPF.BaseLib.ViewModel.Base;
using Boomsa.WPF.BaseLib.Infrastructure.Command;
using System.Windows.Input;
using Fitness.DAL.Entities;
using Fitness.Interfaces;
using System;
using Fitness.WPF.NetCore.Services.Interfaces;
using Fitness.WPF.NetCore.Services;
using System.Windows.Controls;
using Fitness.WPF.NetCore.View.MainFrame;
using System.Threading.Tasks;
using System.Threading;

namespace Fitness.WPF.NetCore.ViewModel
{
    internal class MainViewModel : ViewModelBase, IFrameCanSwitch
    {
        private readonly IRepository<User> _dbUsers;
        private readonly IChangeUserDialog _changeUserDialog;
        private readonly IFrameSwither _frameSwitcher;
        

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

        public MainViewModel(IRepository<User> dbUsers, IChangeUserDialog changeUserDialog, IFrameSwither frameSwitcher)
        {
            _dbUsers = dbUsers;
            _changeUserDialog = changeUserDialog;
            _frameSwitcher = frameSwitcher;
            InitializingSwitcher(frameSwitcher);

            
        }
        public MainViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Использование конструктора для дизайн мода");
            CurrentPage = new DiaryPage();
        }




        #region MenuCommands

        #region Команда ChangeUser
        private ICommand _ChangeUserCommand;
        /// <summary>"Описание"</summary>
        public ICommand ChangeUserCommand =>
        _ChangeUserCommand ??= new LambdaCommand(() => 
        {
            CurrentUser = _changeUserDialog.ChangeUser(CurrentUser);
        });

        #endregion

        #endregion



        #region SwitchPage


        #region  Page CurrentPage Текущий Фрейм
        ///<summary> Текущий Фрейм
        private Page _CurrentPage;
        ///<summary> Текущий Фрейм
        public Page CurrentPage
        {
            get => _CurrentPage;
            set => Set(ref _CurrentPage, value, nameof(CurrentPage));
        }
        #endregion

        #region  double Opacity Текущая прозрачность
        ///<summary> Текущая прозрачность
        private double _FrameOpacity = 1;
        ///<summary> Текущая прозрачность
        public double FrameOpacity
        {
            get => _FrameOpacity;
            set => Set(ref _FrameOpacity, value, nameof(FrameOpacity));
        }
        #endregion
                        
        public ICommand bMenuDiary_Click => new LambdaCommand(
                () => _frameSwitcher.SwitchFrame("Diary"), 
                () => CurrentUser!=null
                );
        public ICommand bMenuProfile_Click => new LambdaCommand(
            () => _frameSwitcher.SwitchFrame("Profile"), 
            () => CurrentUser != null
            );
        public ICommand bMenuRecipe_Click => new LambdaCommand(
            () => _frameSwitcher.SwitchFrame("Recipe")
            );
        private void InitializingSwitcher(IFrameSwither frameSwitcher)
        {
            _frameSwitcher.PageSwitcher = this;
            _frameSwitcher.AddPageToDictionary(new DiaryPage(), "Diary");
            _frameSwitcher.AddPageToDictionary(new ProfilePage(), "Profile");
            _frameSwitcher.AddPageToDictionary(new RecipePage(), "Recipe");
            _frameSwitcher.SwitchFrame("Diary");
        }
        public void SwitchFrame(Page page)
        {
            SlowOpacity(page);

        }
        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i < 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = page;
                
                    for (double i = 0.0; i < 1.1; i += 0.1)
                    {
                        FrameOpacity = i;
                        Thread.Sleep(50);
                    }
                
            }
            );
        }
        #endregion
    }

   
}
