using Fitness.DAL.Entities.Base;

using System;
using System.Collections.Generic;

namespace Fitness.DAL.Entities
{
    public class Exercise : NamedEntity
    {
       

        public double CaloriesPerMinute { get; set; }
        public virtual ICollection<Activities> Activities { get; set; } = new HashSet<Activities>();
     
    }

}
