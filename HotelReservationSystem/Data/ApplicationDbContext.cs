﻿using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
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
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
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
                .WithMany(f => f.RoomFacilities).HasForeignKey(rf => rf.FacilityId);

            modelBuilder.Entity<PictureRoom>().HasOne(pr => pr.Room)
                .WithMany(r => r.RoomPictures).HasForeignKey(pr => pr.RoomId);

            #region Reservations_Relations
            //modelBuilder.Entity<Reservation>()
            //    .HasMany(r => r.Rooms)
            //    .WithMany(r => r.Reservations);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Invoice)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.InvoiceId);
            // relation between payment and reservaion 
            // and customer
            //modelBuilder.Entity<Reservation>().HasOne(r=>r.Payment)
            //    .WithMany(r=>r.resvesions)
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
            #endregion

            #region Resservation
            modelBuilder.Entity<Reservation>().Property(r => r.Status).HasColumnType("Nvarchar(10)");
            #endregion

            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(e => new { e.UserId, e.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            new DbInitializer(modelBuilder).Seed();
        }
    }
}
