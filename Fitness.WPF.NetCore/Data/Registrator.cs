﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using Fitness.DAL.Context;

namespace Fitness.WPF.NetCore.Data
{
  static  class Registrator
    {

        public static IServiceCollection RegisterDataBase(this IServiceCollection services, IConfiguration configuration) => services
               .AddDbContext<FitnessDb>(
                     opt =>
               {
                   var type = configuration["Type"];
                   switch (type)
                   {
                       case "MSSQL":
                           opt.UseSqlServer(configuration.GetConnectionString(type));
                           break;
                       case "SQLite":
                           opt.UseSqlite(configuration.GetConnectionString(type));
                           break;

                       case "InMemory":
                           opt.UseInMemoryDatabase("Bookishness");
                           break;

                       case null: throw new InvalidOperationException("Не определен тип ДБ");
                       default:
                           throw new InvalidOperationException($"Тип подключения {type} не поддерживается");
                   }
               })
            .AddTransient<DBInitializer>();
        
    }
}
