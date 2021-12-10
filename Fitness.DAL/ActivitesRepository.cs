using Fitness.DAL.Context;
using Fitness.DAL.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.DAL
{
    class ActivitesRepository : DbRepository<Activites>
    {
        public ActivitesRepository(FitnessDb db) : base(db)
        {
        }
        public override IQueryable<Activites> Items => base.Items.Include(item => item.Exercises);
    }
}
