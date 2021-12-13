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
    /// Логика взаимодействия для CreateNewUserUC.xaml
    /// </summary>
    public partial class CreateNewUserUC : UserControl
    {


        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CreateNewUserUC), new PropertyMetadata(""));


        public CreateNewUserUC()
        {
            InitializeComponent();
        }
        private void CheckBoxPasswordShow_click(object sender, RoutedEventArgs e)
        {
            var password = PasswordBox1_Password.Password;
            if (password == PasswordBox2_Password.Password)
                TextBoxPassword.Text = password;
        }

        private void Password1_TextInput(object sender, TextCompositionEventArgs e)
        {
            TextBoxPassword.Text = PasswordBox1_Password.Password;
        }
    }
}
