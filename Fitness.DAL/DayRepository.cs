using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fitness.DAL.Context;

using Microsoft.EntityFrameworkCore;

namespace Fitness.DAL.Entities
{
    class DayRepository : DbRepository<Day>
    {
        public DayRepository(FitnessDb db) : base(db)
        {
        }
        public override IQueryable<Day> Items => base.Items
            .Include(items=> items.Eatings)
            .Include(item=> item.Activites);
    }
}
