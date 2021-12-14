using Fitness.WPF.NetCore.View.MainFrame;

using System.Windows.Controls;

namespace Fitness.WPF.NetCore.Services
{
    internal interface IFrameSwither
    {
        IFrameCanSwitch PageSwitcher { get; set; }

        void AddPageToDictionary(Page page, string name);
        void SwitchFrame(string name);
       
    }
}