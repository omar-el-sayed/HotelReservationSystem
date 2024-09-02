using HotelReservationSystem.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Data
{
    public class DbInitializer(ModelBuilder _builder)
    {
        public void Seed()
        {
            _builder.Entity<IdentityRole>(a =>
            {
                a.HasData(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Constants.HotelStaff,
                    NormalizedName = Constants.HotelStaff.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
                a.HasData(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Constants.Customer,
                    NormalizedName = Constants.Customer.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            });
        }
    }
}
