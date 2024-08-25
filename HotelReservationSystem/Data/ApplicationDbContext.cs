using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PictureRoom> PictureRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<RoomOffer> RoomOffers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

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
            #region Reservations_Relations
            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Rooms)
                .WithMany(r => r.Reservations);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Invoice)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.InvoiceId);
            //modelBuilder.Entity<Reservation>()
            //    .HasOne(r => r.Payment)
            //    .WithMany(r => r.Reservations)
            //    .HasForeignKey(r => r.);
            #endregion
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
