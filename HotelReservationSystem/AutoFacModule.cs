using Autofac;
using HotelReservationSystem.Data;
using HotelReservationSystem.Mediators.Payment;
using HotelReservationSystem.Mediators.Reservation;
using HotelReservationSystem.Mediators.Rooms;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.Auth;
using HotelReservationSystem.Services.Facilities;
using HotelReservationSystem.Services.Feedbacks;
using HotelReservationSystem.Services.PictureRooms;
using HotelReservationSystem.Services.Reservations;
using HotelReservationSystem.Services.RoomFacilites;
using HotelReservationSystem.Services.RoomReservations;
using HotelReservationSystem.Services.Rooms;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationSystem
{
    public class AutoFacModule : Module
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
                optionbuilder.UseSqlServer(connectionstring).LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
                return new ApplicationDbContext(optionbuilder.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterAssemblyTypes(typeof(IFacilityService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomFacilityService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomMediator).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IReservationService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IPictureRoomService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IPaymentMediator).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IAuthService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IFeedbackService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomReservationService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IReservationMediator).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();



        }
    }
}
