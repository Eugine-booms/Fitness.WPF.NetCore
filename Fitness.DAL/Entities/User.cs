using Fitness.DAL.Entities.Base;

using System;
using System.Text;

namespace Fitness.DAL.Entities
{
    public class User : NamedEntity
    {
        
        public DateTime Birthday { get; set; }
        public double Weight { get; set; }
        public double Hight { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
   
}
