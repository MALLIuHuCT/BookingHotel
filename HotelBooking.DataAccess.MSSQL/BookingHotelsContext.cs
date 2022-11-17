using System;
using HotelBooking.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelBooking.DataAccess.MSSQL
{
    public partial class BookingHotelsContext : DbContext
    {
        public BookingHotelsContext()
        {
        }

        public BookingHotelsContext(DbContextOptions<BookingHotelsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalService> AdditionalService { get; set; }
        public virtual DbSet<AdditionalServiceType> AdditionalServiceType { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingAdditionalService> BookingAdditionalService { get; set; }
        public virtual DbSet<BookingAssignedPerson> BookingAssignedPerson { get; set; }
        public virtual DbSet<BookingStatus> BookingStatus { get; set; }
        public virtual DbSet<Cheque> Cheque { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelClassification> HotelClassification { get; set; }
        public virtual DbSet<HotelImage> HotelImage { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonImage> PersonImage { get; set; }
        public virtual DbSet<PersonInfo> PersonInfo { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomImage> RoomImage { get; set; }
        public virtual DbSet<RoomInfo> RoomInfo { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<Street> Street { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalService>(entity =>
            {
                entity.ToTable("Additional_Service");

                entity.HasIndex(e => e.ServiceTypeId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(350);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.AdditionalService)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .HasConstraintName("FK_Additional_Service_Additional_Service_Type");
            });

            modelBuilder.Entity<AdditionalServiceType>(entity =>
            {
                entity.ToTable("Additional_Service_Type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasIndex(e => e.BookingStatusId);

                entity.HasIndex(e => e.RoomId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingStatusId).HasColumnName("booking_status_id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("time(6)");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("time(6)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.BookingStatus)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.BookingStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Booking_Status");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Room");
            });

            modelBuilder.Entity<BookingAdditionalService>(entity =>
            {
                entity.ToTable("Booking_Additional_Service");

                entity.HasIndex(e => e.AdditionalServiceId);

                entity.HasIndex(e => e.BookingId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalServiceId).HasColumnName("additional_service_id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("time(6)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("time(6)");

                entity.HasOne(d => d.AdditionalService)
                    .WithMany(p => p.BookingAdditionalService)
                    .HasForeignKey(d => d.AdditionalServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Additional_Service_Additional_Service");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingAdditionalService)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Additional_Service_Booking");
            });

            modelBuilder.Entity<BookingAssignedPerson>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.PersonId });

                entity.ToTable("Booking_Assigned_Person");

                entity.HasIndex(e => e.PersonId);

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingAssignedPerson)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Assigned_Person_Booking");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.BookingAssignedPerson)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Assigned_Person_Person_Info");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.ToTable("Booking_Status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cheque>(entity =>
            {
                entity.HasIndex(e => e.BookingId);

                entity.HasIndex(e => e.PaymentTypeId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentTime)
                    .HasColumnName("payment_time")
                    .HasColumnType("time(6)");

                entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Cheque)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cheque_Booking");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Cheque)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cheque_Payment_Type");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasIndex(e => e.HotelClassId);

                entity.HasIndex(e => e.ImageId);

                entity.HasIndex(e => e.StreetId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HomeNumber).HasColumnName("home_number");

                entity.Property(e => e.HotelClassId).HasColumnName("hotel_class_id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Stars).HasColumnName("stars");

                entity.Property(e => e.StreetId).HasColumnName("street_id");

                entity.HasOne(d => d.HotelClass)
                    .WithMany(p => p.Hotel)
                    .HasForeignKey(d => d.HotelClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hotel_Hotel_Classification");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Hotel)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Hotel_Hotel_Image");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Hotel)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hotel_Street");
            });

            modelBuilder.Entity<HotelClassification>(entity =>
            {
                entity.ToTable("Hotel_Classification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HotelImage>(entity =>
            {
                entity.ToTable("Hotel_Image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("Payment_Type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => new { e.IdInt, e.IdGuid })
                    .IsClustered(false);

                entity.HasIndex(e => e.IdGuid);

                entity.HasIndex(e => e.IdInt);

                entity.Property(e => e.IdInt).HasColumnName("id_int");

                entity.Property(e => e.IdGuid).HasColumnName("id_guid");

                entity.HasOne(d => d.IdGu)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.IdGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_AspNetUsers");

                entity.HasOne(d => d.IdIntNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.IdInt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Person_Info");
            });

            modelBuilder.Entity<PersonImage>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("Person_Image");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasColumnType("image");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.PersonImage)
                    .HasForeignKey<PersonImage>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Image_Person_Info");
            });

            modelBuilder.Entity<PersonInfo>(entity =>
            {
                entity.ToTable("Person_Info");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Middlename)
                    .IsRequired()
                    .HasColumnName("middlename")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasIndex(e => e.HotelId);

                entity.HasIndex(e => e.RoomTypeId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");

                entity.Property(e => e.SpecialCost).HasColumnName("special_cost");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.HotelId);

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Room_Type");
            });

            modelBuilder.Entity<RoomImage>(entity =>
            {
                entity.ToTable("Room_Image");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<RoomInfo>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.ToTable("Room_Info");

                entity.HasIndex(e => e.ImageId);

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Balcony).HasColumnName("balcony");

                entity.Property(e => e.Bathroom).HasColumnName("bathroom");

                entity.Property(e => e.Conditioner).HasColumnName("conditioner");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.Kitchen).HasColumnName("kitchen");

                entity.Property(e => e.RoomsAmount).HasColumnName("rooms_amount");

                entity.Property(e => e.SoundIsolation).HasColumnName("sound_isolation");

                entity.Property(e => e.SquareMeters)
                    .HasColumnName("square_meters")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Tv).HasColumnName("tv");

                entity.Property(e => e.WashingMachine).HasColumnName("washing_machine");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.RoomInfo)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Room_Info_Room_Image");

                entity.HasOne(d => d.Room)
                    .WithOne(p => p.RoomInfo)
                    .HasForeignKey<RoomInfo>(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Info_Room");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("Room_Type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.HasIndex(e => e.CityId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Street)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Street_City");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
