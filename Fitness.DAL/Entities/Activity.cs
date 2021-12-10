using Fitness.DAL.Entities.Base;

using System.Collections.Generic;

namespace Fitness.DAL.Entities
{
    public class Activity : NamedEntity
    {
        public virtual ICollection<Exercise> Exercises { get; set; }
        public double CaloriesPerMinute { get; set; }
    }
}
