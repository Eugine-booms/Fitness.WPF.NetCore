using Boomsa.WPF.BaseLib.ViewModel.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.Services.Interfaces
{
  public  interface ISwitcher
    {
        void Navigate(ViewModelBase model);
    }
}
