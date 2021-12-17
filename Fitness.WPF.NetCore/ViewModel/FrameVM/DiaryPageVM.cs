

using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.DAL.Entities;
using Fitness.Interfaces;
using Fitness.WPF.NetCore.Services;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.ViewModel.FrameVM
{
    class DiaryPageVM : ViewModelBase
    {
        private readonly IRepository<Day> _days;
        private readonly MainViewModel _mainModel;
        private User _user;


       
        public DiaryPageVM(IRepository<Day> days)
        {
            _days = days;
            _user = CurrentUserInformation.User;
            CurrentUserInformation.UserChangeEvent += CurrentUserInformation_UserChangeEvent;
        }

        private void CurrentUserInformation_UserChangeEvent(object sender, EventArgs e)
        {
            WeekCount = WeekCountComputer(SelectedDay);
        }

        /// <summary>
        /// Конструктор для дизайнера
        /// </summary>
        public DiaryPageVM()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Использование конструктора для дизайн мода");
            _user= new User {StartTime=DateTime.Now.AddDays(-40) };
        }



        #region Верхний док
        #region  DateTime SelectedDay Выбранный день, по умолчанию сегодня
        ///<summary> Выбранный день, по умолчанию сегодня
        private DateTime _SelectedDay = DateTime.Now;
        ///<summary> Выбранный день, по умолчанию сегодня
        public DateTime SelectedDay
        {
            get => _SelectedDay;
            set
            {
                if (!Set(ref _SelectedDay, value, nameof(SelectedDay))) return;
                CurrentDay = ConvertDayToString(value);
                WeekCount = WeekCountComputer(value);
            }
        }
        #endregion

        #region  string CurrentDay Отображение текущего выбранного дня 
        ///<summary> Отображение текущего выбранного дня 
        private string _CurrentDay;
        ///<summary> Отображение текущего выбранного дня 
        public string CurrentDay
        {
            get => _CurrentDay;
            set
            {
                Set(ref _CurrentDay, value, nameof(CurrentDay));
            }
        }

        private string ConvertDayToString(DateTime selectedDay)
        {
            var nowDate = DateTime.Now.Date;
            var difference = nowDate - selectedDay;
            switch (difference.Days)
            {
                case 0:
                    return "Сегодня";
                case 1:
                    return "Вчера";


                case 2:
                    return "Позавчера";
                case -1:
                    return "Завтра";
                case -2:
                    return "Послезавтра";
                default:
                    return difference.Days.ToString();
            }
        }
        #endregion


        #region  string WeekCount Отображение текущей недели
        private string _WeekCount;
        public string WeekCount
        {
            get => _WeekCount;
            set => Set(ref _WeekCount, value);
        }
        #endregion


        #endregion



        private void GetDayInformation()
        {
            var dayInfo = _days.Items.SingleOrDefault(day => day.User == _user && day.Date == SelectedDay);
        }
        private string WeekCountComputer(DateTime dateTime)
        {
            var startTime = CurrentUserInformation.User.StartTime;
            var now = dateTime;
            var dif = (now - startTime).Days / 7;
            return $"Неделя {dif}";
        }
    }
}
