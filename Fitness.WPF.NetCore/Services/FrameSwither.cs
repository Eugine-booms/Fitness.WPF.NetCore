using Boomsa.WPF.BaseLib.ViewModel.Base;

using Fitness.WPF.NetCore.Services.Interfaces;
using Fitness.WPF.NetCore.View.MainFrame;
using Fitness.WPF.NetCore.ViewModel;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fitness.WPF.NetCore.Services
{
    internal class FrameSwither : IFrameSwither
    {
        private Dictionary<string, Page> dictionary;

        private IFrameCanSwitch pageSwitcher;  //MV Которая умеет переключать фреймы
        public IFrameCanSwitch PageSwitcher { get =>pageSwitcher; set=>pageSwitcher=value; }
        public FrameSwither()
        {
            this.dictionary = new Dictionary<string, Page>();
        }
        
        public void AddPageToDictionary(Page page, string name)
        {
            dictionary.Add(name, page);
        }

        public void SwitchFrame(string name)
        {
            var frame = dictionary[name];
            pageSwitcher.SwitchFrame(frame);
        }

       
    }
}
