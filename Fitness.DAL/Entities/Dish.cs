using Fitness.DAL.Entities.Base;

namespace Fitness.DAL.Entities
{
    public class Dish : NamedEntity
    {
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Calories { get; set; }
        public virtual Eating Eating { get; set; }
    }

}
