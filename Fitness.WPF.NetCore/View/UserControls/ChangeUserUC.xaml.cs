using Fitness.DAL.Entities;
using Fitness.WPF.NetCore.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fitness.WPF.NetCore.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ChangeUserUC.xaml
    /// </summary>
    public partial class ChangeUserUC : UserControl , ISwitchable
    {
        private User user;

        public ChangeUserUC()
        {
            InitializeComponent();
        }

        public ChangeUserUC(User user)
        {
            this.user = user;
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
