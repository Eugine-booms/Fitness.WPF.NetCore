using Fitness.DAL.Entities.Base;

namespace Fitness.DAL.Entities
{
    public class Nutrition  : Entity
    {
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
    }
}
