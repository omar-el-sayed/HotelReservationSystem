using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using HotelReservationSystem;
using HotelReservationSystem.Data;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Middlewares;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.Auth;
using HotelReservationSystem.ViewModels.Facilities;
using HotelReservationSystem.ViewModels.Payments;
using HotelReservationSystem.ViewModels.PictureRooms;
using HotelReservationSystem.ViewModels.RoomFailites;
using HotelReservationSystem.ViewModels.Rooms;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Stripe;
using System.Text;

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

builder.Services.Configure<Jwt>(builder.Configuration.GetSection(nameof(Jwt)));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAutoMapper(
    typeof(RoomProfile),
    typeof(PaymentProfile),
    typeof(FacilityProfile),
    typeof(PictureRoomProfile),
    typeof(RoomFacilityProfile),
    typeof(AuthProfile));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

var app = builder.Build();

MapperHelper.mapper = app.Services.GetService<IMapper>()!;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandlerMiddleware>();
//app.UseMiddleware<TransactionHandlerMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
