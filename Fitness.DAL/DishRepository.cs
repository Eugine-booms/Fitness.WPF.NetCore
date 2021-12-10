using Fitness.DAL.Context;
using Fitness.DAL.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.DAL
{
    class DishRepository : DbRepository<Dish>
    {
        public DishRepository(FitnessDb db) : base(db) { }
        public override IQueryable<Dish> Items => base.Items.Include(item => item.Eating);
    }
}
