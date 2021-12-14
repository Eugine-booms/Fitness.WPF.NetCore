using Fitness.DAL.Entities;

namespace Fitness.WPF.NetCore.Services.Interfaces
{
  interface IChangeUserDialog
    {
        User ChangeUser(User currentUser);
    }
}