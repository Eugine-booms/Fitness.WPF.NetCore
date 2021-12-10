using Fitness.DAL.Context;
using Fitness.DAL.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.DAL
{
    internal class ExerciseRepository : DbRepository<Exercise>
    {
        public ExerciseRepository(FitnessDb db) : base(db) { }
        public override IQueryable<Exercise> Items => base.Items.Include(item => item.Activities);

    }
}
