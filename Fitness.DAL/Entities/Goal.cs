using Fitness.DAL.Entities.Base;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Fitness.DAL.Entities
{
    public  class Goal : Entity

    {
        public int NumberOfSteps { get; set; }
        public double GoalForTheWeek { get; set; }
        public double DesiredWeight { get; set; }
        public Purpose Purpose { get; set; }
        public ActivityLevel ActivityLevel{ get; set; }
        
        //  public Nutrition Nutrition { get; set; }
    }
}
