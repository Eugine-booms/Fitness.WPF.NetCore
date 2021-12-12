using Fitness.DAL.Context;
using Fitness.DAL.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.DAL
{
    class ActivitiesRepository : DbRepository<Activities>
    {
        public ActivitiesRepository(FitnessDb db) : base(db)
        {
        }
        public override IQueryable<Activities> Items => base.Items.Include(item => item.Exercises);
    }
}
