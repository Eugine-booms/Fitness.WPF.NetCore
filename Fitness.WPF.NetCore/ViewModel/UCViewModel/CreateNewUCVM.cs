using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.WPF.NetCore.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.ViewModel.UCViewModel
{
    public class CreateNewUCVM : ViewModelBase  , ISwitchable
    {
        public CreateNewUCVM()
        {
            //if (!App.IsDesignTime)
            //    throw new InvalidOperationException("Использование конструктора для дизайн мода");
        }

        internal PageSwitcherVM ParentVM;

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
