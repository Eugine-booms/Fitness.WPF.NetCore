using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.WPF.NetCore.Services.Interfaces;
using Fitness.WPF.NetCore.View.Windows;
using Fitness.WPF.NetCore.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fitness.WPF.NetCore.Services
{
   public static class Switcher  
    {
        public static ViewModelBase pageSwitcher;

        public static void Switch(ViewModelBase newPage)
        {
           ((PageSwitcherVM) pageSwitcher).Navigate(newPage);
        }

       
    }
}
