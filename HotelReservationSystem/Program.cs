using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using HotelReservationSystem;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Middlewares;
using HotelReservationSystem.ViewModels.Facilities;
using HotelReservationSystem.ViewModels.Payments;
using HotelReservationSystem.ViewModels.PictureRooms;
using HotelReservationSystem.ViewModels.RoomFailites;
using HotelReservationSystem.ViewModels.Rooms;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerbuilder =>
{
    containerbuilder.RegisterModule(new AutoFacModule(builder.Configuration));
});

builder.Services.AddAutoMapper(typeof(RoomProfile), typeof(PaymentProfile), typeof(FacilityProfile), typeof(PictureRoomProfile), typeof(RoomFacilityProfile));

StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

var app = builder.Build();

MapperHelper.mapper = app.Services.GetService<IMapper>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandlerMiddleware>();
//app.UseMiddleware<TransactionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
