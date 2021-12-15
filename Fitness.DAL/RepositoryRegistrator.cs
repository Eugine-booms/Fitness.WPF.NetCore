using Fitness.DAL.Entities;
using Fitness.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Fitness.DAL
{
  public  static class RepositoryRegistrator
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services) => services
           .AddTransient<IRepository<User>, UserRepository>()
           .AddTransient<IRepository<Exercise>, ExerciseRepository>()
           .AddTransient<IRepository<Activities>, ActivitiesRepository>()
           .AddTransient<IRepository<Dish>, DishRepository>()
           .AddTransient<IRepository<Eating>, EatingRepository>()
            .AddTransient<IRepository<Day>, DayRepository>();
    }
}
