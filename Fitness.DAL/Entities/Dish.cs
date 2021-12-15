using Fitness.DAL.Entities.Base;

using System.Collections.Generic;

namespace Fitness.DAL.Entities
{
    public class Dish : NamedEntity
    {
        public Nutrition Nutrition { get; set; }
        public double Calories { get; set; }
        public virtual ICollection<Eating> Eating { get; set; } = new HashSet<Eating>();
        
    }

}
