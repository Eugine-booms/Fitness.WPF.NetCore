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
            //await InitialBooks();
            //await InitialBuyers();
            //await InitialSellers();
            //await InitialDeals();
            __loger.LogInformation("Инициализация выполнена за {0} мc.", timer.ElapsedMilliseconds - tempTime);
            timer.Stop();
        }


        private const int __UserCount = 10;
        private User[] _Users;

        private async Task InitializeUser()
        {
            var timer = Stopwatch.StartNew();
            __loger.LogInformation("Инициализация категорий...");

            _Users = new User[__UserCount];
            for (int i = 0; i < __UserCount; i++)
            {
                _Users[i] = new User()
                {
                    Name = $"User {i + 1}",
                    Birthday = DateTime.Now,
                    Email=$"Emale User_{i}@mail.ru",
                    Hight=180.0,
                    Weight=120.0,
                    Password="password"
                };
            }
            await __db.AddRangeAsync(_Users);
            await __db.SaveChangesAsync();
            __loger.LogInformation("Инициализация категорий выполнена за {0} мc.", timer.ElapsedMilliseconds);
        }
        //private const int __booksCount = 10;
        //private Book[] _books;
        //private async Task InitialBooks()
        //{
        //    var timer = Stopwatch.StartNew();
        //    __loger.LogInformation("Инициализация книг...");

        //    var rnd = new Random();
        //    _books = new Book[__booksCount];
        //    _books = Enumerable.Range(1, __booksCount)
        //        .Select(b => new Book { Name = $" Книга {b + 1}", Category = rnd.NextItem(_categories) })
        //        .ToArray();
        //    await __db.AddRangeAsync(_books);
        //    await __db.SaveChangesAsync();

        //    __loger.LogInformation("Инициализация книг выполнена за {0} мc.", timer.ElapsedMilliseconds);
        //}

        //private const int __sellerscount = 10;
        //private Seller[] _sellers;
        //private async Task InitialSellers()
        //{
        //    var timer = Stopwatch.StartNew();
        //    __loger.LogInformation("Инициализация Продавцов...");

        //    _sellers = new Seller[__sellerscount];
        //    _sellers = Enumerable.Range(1, __sellerscount)
        //        .Select(s => new Seller()
        //        {
        //            Name = $" Продавец- Имя {s + 1}",
        //            Surname = $"Продавец-фамилия {s + 1}",
        //            Patronymic = $" Продавец-отчество {s + 1}"
        //        })
        //        .ToArray();
        //    await __db.AddRangeAsync(_sellers);
        //    await __db.SaveChangesAsync();

        //    __loger.LogInformation("Инициализация продавцов выполнена за {0} мc.", timer.ElapsedMilliseconds);
        //}

        //private const int __buyersCount = 10;
        //private Buyer[] _buyers;
        //private async Task InitialBuyers()
        //{
        //    var timer = Stopwatch.StartNew();
        //    __loger.LogInformation("Инициализация покупателей...");
        //    _buyers = new Buyer[__buyersCount];
        //    _buyers = Enumerable.Range(1, __buyersCount)
        //        .Select(s => new Buyer()
        //        {
        //            Name = $" Покупатель- Имя {s + 1}",
        //            Surname = $"Покупатель-фамилия {s + 1}",
        //            Patronymic = $" Покупатель-отчество {s + 1}"
        //        })
        //        .ToArray();
        //    await __db.AddRangeAsync(_buyers);
        //    await __db.SaveChangesAsync();
        //    __loger.LogInformation("Инициализация покупателей выполнена за {0} мc.", timer.ElapsedMilliseconds);
        //}

        //private const int __dealsCount = 1000;

        //private async Task InitialDeals()
        //{
        //    var timer = Stopwatch.StartNew();
        //    __loger.LogInformation("Инициализация сделок...");
        //    var rnd = new Random();
        //    var _deals = Enumerable.Range(1, __dealsCount)
        //        .Select(s => new Deal()
        //        {
        //            Book = rnd.NextItem(_books),
        //            Buyer = rnd.NextItem(_buyers),
        //            Seller = rnd.NextItem(_sellers),
        //            Price = (decimal)(rnd.NextDouble() * 4000 + 700)
        //        });
        //    await __db.AddRangeAsync(_deals);
        //    await __db.SaveChangesAsync();
        //    __loger.LogInformation("Инициализация Сделок выполнена за {0} мc.", timer.Elapsed.TotalSeconds);
        //    timer.Stop();
        //}
    }
}
