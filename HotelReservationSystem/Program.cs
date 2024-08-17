using HotelReservationSystem.Middlewares;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HotelReservationSystem;
using HotelReservationSystem.Profiles;
using HotelReservationSystem.Helpers;
using AutoMapper;

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
builder.Services.AddAutoMapper(typeof(RoomProfile));
var app = builder.Build();
MapperHelper.mapper = app.Services.GetService<IMapper>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
