using Fitness.DAL.Entities;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.DAL
{
   static class RepositoryRegistrator
    {
        public static IServiceCollection RegistrRepository(this IServiceCollection services) => services
           .AddTransient<DbRepository<User>, UserRepository>()
           .AddTransient<DbRepository<Exercise>, ExerciseRepository>()
           .AddTransient<DbRepository<Activites>, ActivitesRepository>()
           .AddTransient<DbRepository<Dish>, DishRepository>()
           .AddTransient<DbRepository<Eating>, EatingRepository>();
    }
}
