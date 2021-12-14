using Fitness.DAL.Context;
using Fitness.DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fitness.WPF.NetCore.Data
{
    class DBInitializer
    {

        private readonly FitnessDb __db;
        private readonly ILogger<DBInitializer> __loger;

        public DBInitializer(FitnessDb db, ILogger<DBInitializer> loger)
        {
            this.__db = db ?? throw new ArgumentNullException(nameof(db));
            this.__loger = loger ?? throw new ArgumentNullException(nameof(loger));
        }

        public void Initialize()
        {
            __db.Database.EnsureDeleted();
            __db.Database.Migrate();
        }

        public async Task InitializeAsync()
        {
            var timer = new Stopwatch();
            timer.Start();
            __loger.LogInformation("Инициализация БД...");
            
            //ToDo
            __loger.LogInformation("Удаление предыдушей БД...");
            await __db.Database.EnsureDeletedAsync().ConfigureAwait(false); //для отладки потом убрать 
                                                                            //__db.Database.EnsureCreated(); //проверяет есть ли база и создает
            var tempTime = timer.ElapsedMilliseconds;
            __loger.LogInformation("Удаление существующей БД выполнено за {0} мc.", tempTime);
            await __db.Database.MigrateAsync(); //проверяет, создает если нет, накатывает миграции
            __loger.LogInformation("Миграция выполнена за {0} мc.", timer.ElapsedMilliseconds - tempTime);
            tempTime = timer.ElapsedMilliseconds;

            if (await __db.Users.AnyAsync()) return;
            await InitializeUser();
            await InitialDays();
            await InitialDish();
            await InitialEating();
            await InitialExercise();
            await InitialActivity();

            __loger.LogInformation("Инициализация выполнена за {0} мc.", timer.ElapsedMilliseconds - tempTime);
            timer.Stop();  
        }


        private const int __UserCount = 10;
        private User[] _Users;

        private async Task InitializeUser()
        {
            var timer = Stopwatch.StartNew();
            __loger.LogInformation("Инициализация пользователей ...");

            _Users = new User[__UserCount];
            for (int i = 0; i < __UserCount; i++)
            {
                _Users[i] = new User()
                {
                    Name = $"User {i + 1}",
                    Birthday = DateTime.Now,
                    Gender = i > 4 ? Gender.Famale : Gender.Male,
                    Email = $"Email User_{i}@mail.ru",
                    Hight = 180.0,
                    Weight = 120.0,
                    Lastlogin = DateTime.Now,
                    Password="password"
                };
            }
            await __db.AddRangeAsync(_Users);
            await __db.SaveChangesAsync();
            __loger.LogInformation("Инициализация Пользователей выполнена за {0} мc.", timer.ElapsedMilliseconds);
        }
        private const int __DayCount = 30;
        private Day[] _Days;
        private async Task InitialDays()
        {
            var timer = Stopwatch.StartNew();
            __loger.LogInformation("Инициализация дней  ...");

            var rnd = new Random();
            _Days = new Day[__DayCount];
            _Days = Enumerable.Range(1, __DayCount)
                .Select(a =>
                new Day
                {
                   User = rnd.NextItem(_Users)
                })
                .ToArray();
            await __db.AddRangeAsync(_Days);
            await __db.SaveChangesAsync();

            __loger.LogInformation("Инициализация активностей выполнена за {0} мc.", timer.ElapsedMilliseconds);
        }



        private const int __dishCount = 10;
        private Dish[] _dishes;
        private async Task InitialDish()
        {
            var timer = Stopwatch.StartNew();
            __loger.LogInformation("Инициализация блюд...");

            var rnd = new Random();
            _dishes = new Dish[__dishCount];
            _dishes = Enumerable.Range(1, __dishCount)
                .Select(d => 
                new Dish 
                {
                    Name =$"Блюдо {d}", 
                    Calories=d*rnd.NextDouble()+rnd.NextDouble(),
                    Carbohydrates= d * rnd.NextDouble() + rnd.NextDouble(),
                    Fats= d * rnd.NextDouble() + rnd.NextDouble(),
                    Proteins= d * rnd.NextDouble() + rnd.NextDouble()
                })
                .ToArray();
            await __db.AddRangeAsync( _dishes);
            await __db.SaveChangesAsync();

            __loger.LogInformation("Инициализация блюд выполнена за {0} мc.", timer.ElapsedMilliseconds);
        }
        private const int __eatingCount = 10;
        private Eating[] _eating;
        private async Task InitialEating()
        {
            var timer = Stopwatch.StartNew();
            __loger.LogInformation("Инициализация приемов пищи...");

            var rnd = new Random();
            _eating = new Eating[__eatingCount];
            _eating = Enumerable.Range(1, __eatingCount)
                .Select(d =>
                new Eating
                {
                    Name = $"Прием пищи № {d}",
                    Moment = DateTime.Now,
                    Day = rnd.NextItem(_Days),
                    Dishes=Enumerable.Range(2,3).Select(d=>rnd.NextItem(_dishes)).ToList(),
                })
                .ToArray();
            await __db.AddRangeAsync(_eating);
            await __db.SaveChangesAsync();

            __loger.LogInformation("Инициализация приемов пищи выполнена за {0} мc.", timer.ElapsedMilliseconds);
        }
        private const int __exerciseCount = 10;
        private Exercise[] _exercise;
        private async Task InitialExercise()
        {
            var timer = Stopwatch.StartNew();
            __loger.LogInformation("Инициализация упражнений пищи...");

            var rnd = new Random();
            _exercise = new Exercise[__exerciseCount];
            _exercise = Enumerable.Range(1, __exerciseCount)
                .Select(e =>
                new Exercise
                {
                    Name = $"Упражнение  {e}",
                    CaloriesPerMinute=rnd.NextDouble()*(e+1)
                })
                .ToArray();
            await __db.AddRangeAsync(_exercise);
            await __db.SaveChangesAsync();

            __loger.LogInformation("Инициализация упражнений выполнена за {0} мc.", timer.ElapsedMilliseconds);
        }
        private const int __activityCount = 10;
        private Activities[] _activity;
        private async Task InitialActivity()
        {
            var timer = Stopwatch.StartNew();
            __loger.LogInformation("Инициализация Активностей  ...");

            var rnd = new Random();
            _activity = new Activities[__activityCount];
            _activity = Enumerable.Range(1, __activityCount)
                .Select(a =>
                new Activities
                {
                    Name = $"Активность  {a}",
                    Exercises = Enumerable.Range(1, 5).Select(ex => rnd.NextItem(_exercise)).ToList() ,
                    Start=DateTime.Now.AddHours(-2),
                    Finish=DateTime.Now ,
                    Day = rnd.NextItem(_Days),
                })
                .ToArray();
            await __db.AddRangeAsync(_activity);
            await __db.SaveChangesAsync();

            __loger.LogInformation("Инициализация активностей выполнена за {0} мc.", timer.ElapsedMilliseconds);
        }


    }
}
