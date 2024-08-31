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
                    Name = "HotelStaff",
                    NormalizedName = "HotelStaff".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
                a.HasData(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Customer",
                    NormalizedName = "Customer".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            });
        }
    }
}
