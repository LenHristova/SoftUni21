﻿using System;

namespace BusTickets.Client
{
    using System.IO;
    using AutoMapper;
    using Core;
    using Core.Contracts;
    using Core.IO;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using Services;
    using Services.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            var service = ConfigureServices();
            var engine = service.GetService<IEngine>();
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddDbContext<BusTicketsContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<BusTicketspProfile>());

            serviceCollection.AddSingleton<IEngine, Engine>();
            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IRepository<BankAccount>, Repository<BankAccount>>();
            serviceCollection.AddTransient<IRepository<Company>, Repository<Company>>();
            serviceCollection.AddTransient<IRepository<Country>, Repository<Country>>();
            serviceCollection.AddTransient<IRepository<Customer>, Repository<Customer>>();
            serviceCollection.AddTransient<IRepository<Review>, Repository<Review>>();
            serviceCollection.AddTransient<IRepository<Station>, Repository<Station>>();
            serviceCollection.AddTransient<IRepository<Ticket>, Repository<Ticket>>();
            serviceCollection.AddTransient<IRepository<Town>, Repository<Town>>();
            serviceCollection.AddTransient<IRepository<Trip>, Repository<Trip>>();
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<IReader, ConsoleReader>();
            serviceCollection.AddTransient<IWriter, ConsoleWriter>();


            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
