using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=HotelReservationSystem;Trusted_Connection=True;TrustServerCertificate=True")
        //        .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region RelationShips
            modelBuilder.Entity<RoomOffer>().HasOne(or => or.Room)
                    .WithMany(r => r.RoomOffers).HasForeignKey(or => or.RoomId);

            modelBuilder.Entity<RoomOffer>().HasOne(or => or.Offer)
                .WithMany(o => o.RoomOffers).HasForeignKey(or => or.OfferId);


            modelBuilder.Entity<RoomFacility>().HasOne(rf => rf.Room)
                .WithMany(r => r.RoomFacilities).HasForeignKey(rf => rf.RoomId);

            modelBuilder.Entity<RoomFacility>().HasOne(rf => rf.Facility)
                .WithMany(f => f.RoomFacilities).HasForeignKey(rf => rf.FacilitiesId);

            modelBuilder.Entity<PictureRoom>().HasOne(pr => pr.Room)
                .WithMany(r => r.RoomPictures).HasForeignKey(pr => pr.RoomId);
            #endregion

            #region Facility
            modelBuilder.Entity<Facility>().Property(f => f.Name).HasMaxLength(50);
            modelBuilder.Entity<Facility>().Property(f => f.Description).HasMaxLength(2000);
            #endregion

            #region Offer
            modelBuilder.Entity<Offer>().Property(o => o.Name).HasMaxLength(50);
            #endregion

            #region PictureRoom
            modelBuilder.Entity<PictureRoom>().Property(pr => pr.Description).HasMaxLength(2000);
            #endregion

            #region Room
            modelBuilder.Entity<Room>().Property(r => r.RoomType).HasColumnType("varchar(10)");
            modelBuilder.Entity<Room>().Property(r => r.Price).HasColumnType("money");
            modelBuilder.Entity<Room>().Property(r => r.AvailableStatus).HasColumnType("varchar(20)"); 
            #endregion


        }
    }
}
