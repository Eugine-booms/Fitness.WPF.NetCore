using Fitness.DAL.Entities.Base;

using System;
using System.Collections.Generic;

namespace Fitness.DAL.Entities
{
    public class Activites : NamedEntity
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
       
    }
}
