using Fitness.DAL.Entities.Base;

using System;
using System.Collections.Generic;

namespace Fitness.DAL.Entities
{
    public class Activities : NamedEntity
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public  Day Day { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
       
    }
}
