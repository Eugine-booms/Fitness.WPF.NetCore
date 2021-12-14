using Fitness.DAL.Context;
using Fitness.DAL.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.DAL
{
    class EatingRepository : DbRepository<Eating>
    {
        public EatingRepository(FitnessDb db) : base(db) { }
        public override IQueryable<Eating> Items => base.Items
            .Include(items => items.Dishes)
            .Include(items=>items.Day);
    }
}
