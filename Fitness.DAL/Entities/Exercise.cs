using Fitness.DAL.Entities.Base;

using System;
using System.Collections.Generic;

namespace Fitness.DAL.Entities
{
    public class Exercise : NamedEntity
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }

    }

}
