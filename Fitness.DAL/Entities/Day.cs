using Fitness.DAL.Entities.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.DAL.Entities
{
  public  class Day   : Entity
    {
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Activities> Activites { get; set; } = new HashSet<Activities>();
        public virtual ICollection <Eating> Eatings { get; set; } = new HashSet<Eating>();
    }
}
