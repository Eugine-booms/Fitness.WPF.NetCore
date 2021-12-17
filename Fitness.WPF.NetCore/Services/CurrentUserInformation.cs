using Fitness.DAL.Entities;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.Services
{
    static class CurrentUserInformation
    {
        public static event EventHandler UserChangeEvent;
        private static User _user = new User();
        static public User User
        {
            get => _user;
            set
            {
                _user = value;
                UserChangeEvent?.Invoke(User, new EventArgs());
            }
        }
    }
}
