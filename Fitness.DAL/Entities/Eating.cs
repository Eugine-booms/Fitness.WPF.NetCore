using Fitness.DAL.Entities.Base;

using System;
using System.Collections.Generic;

namespace Fitness.DAL.Entities
{
    public class Eating : NamedEntity
    {
        public DateTime Moment { get; set; }
        public User User { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; } = new HashSet<Dish>();
       
    }

}
