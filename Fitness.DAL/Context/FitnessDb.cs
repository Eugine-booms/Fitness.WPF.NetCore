using Fitness.DAL.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.DAL.Context
{
   public class FitnessDb : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Activities> Activities { get; set; }

        public FitnessDb(DbContextOptions<FitnessDb> options) : base(options) { }
    
    }
}
