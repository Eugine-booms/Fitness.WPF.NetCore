using Fitness.DAL.Entities.Base;

using System.Collections.Generic;

namespace Fitness.DAL.Entities
{
    public class Dish : NamedEntity
    {
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Calories { get; set; }
        public virtual ICollection<Eating> Eating { get; set; } = new HashSet<Eating>();
        
    }

}
