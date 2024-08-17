﻿using Autofac;
using HotelReservationSystem.Data;
using HotelReservationSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationSystem
{
    public class AutoFacModule :Module
    {
        private readonly IConfiguration configration;

        public AutoFacModule(IConfiguration configration)
        {
            this.configration = configration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var optionbuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionstring = configration.GetConnectionString("connectionstring");
                optionbuilder.UseSqlServer(connectionstring).LogTo(log=>Debug.WriteLine(log),LogLevel.Information)
                .EnableSensitiveDataLogging();
                return new ApplicationDbContext(optionbuilder.Options);
            }).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
        }
    }
}
