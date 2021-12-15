

using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.DAL.Entities;
using Fitness.Interfaces;

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


        public DiaryPageVM(IRepository<Day> days)
        {

            _days = days;
            // _user = PageSwitcherVM;
        }
        public DiaryPageVM()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Использование конструктора для дизайн мода");
        }
    }
}
