using Fitness.DAL.Entities.Base;

using System;
using System.Collections.Generic;
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
        public DateTime Lastlogin { get; set; }
        public virtual ICollection<Activities> Activites { get; set; }  = new HashSet<Activities>();
              
       
    }
}
