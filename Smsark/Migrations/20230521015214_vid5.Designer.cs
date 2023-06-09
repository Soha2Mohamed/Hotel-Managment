﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smsark.Models;

#nullable disable

namespace Smsark.Migrations
{
    [DbContext(typeof(SmsarkDb))]
    [Migration("20230521015214_vid5")]
    partial class vid5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Smsark.Models.Apartment", b =>
                {
                    b.Property<int>("ApartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfBathrooms")
                        .HasColumnType("int");

                    b.Property<int>("NoOfBeds")
                        .HasColumnType("int");

                    b.Property<int>("NoOfRooms")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WiFi")
                        .HasColumnType("bit");

                    b.HasKey("ApartmentId");

                    b.HasIndex("OwnerId");

                    b.ToTable("apartments");
                });

            modelBuilder.Entity("Smsark.Models.Bed", b =>
                {
                    b.Property<int>("BedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BedId"));

                    b.Property<float>("BedPrice")
                        .HasColumnType("real");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("BedId");

                    b.HasIndex("RoomId");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("Smsark.Models.Customer", b =>
                {
                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NationalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.HasKey("CustomerEmail");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Smsark.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NationalId")
                        .HasColumnType("bigint");

                    b.Property<string>("NationalIdPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.ToTable("owners");
                });

            modelBuilder.Entity("Smsark.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("checkin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("checkout")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerEmail");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("Smsark.Models.ReservationItem", b =>
                {
                    b.Property<int>("ReservationItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationItemID"));

                    b.Property<int>("BedId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("ReservationItemID");

                    b.HasIndex("BedId");

                    b.HasIndex("ReservationId");

                    b.ToTable("reservationItems");
                });

            modelBuilder.Entity("Smsark.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Smsark.Models.Apartment", b =>
                {
                    b.HasOne("Smsark.Models.Owner", "Owner")
                        .WithMany("apartments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Smsark.Models.Bed", b =>
                {
                    b.HasOne("Smsark.Models.Room", "room")
                        .WithMany("Beds")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");
                });

            modelBuilder.Entity("Smsark.Models.Reservation", b =>
                {
                    b.HasOne("Smsark.Models.Customer", "Customer")
                        .WithMany("reservations")
                        .HasForeignKey("CustomerEmail");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Smsark.Models.ReservationItem", b =>
                {
                    b.HasOne("Smsark.Models.Bed", "bed")
                        .WithMany("reservationItems")
                        .HasForeignKey("BedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smsark.Models.Reservation", "reservation")
                        .WithMany("reservationItems")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bed");

                    b.Navigation("reservation");
                });

            modelBuilder.Entity("Smsark.Models.Room", b =>
                {
                    b.HasOne("Smsark.Models.Apartment", "apartment")
                        .WithMany("rooms")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("apartment");
                });

            modelBuilder.Entity("Smsark.Models.Apartment", b =>
                {
                    b.Navigation("rooms");
                });

            modelBuilder.Entity("Smsark.Models.Bed", b =>
                {
                    b.Navigation("reservationItems");
                });

            modelBuilder.Entity("Smsark.Models.Customer", b =>
                {
                    b.Navigation("reservations");
                });

            modelBuilder.Entity("Smsark.Models.Owner", b =>
                {
                    b.Navigation("apartments");
                });

            modelBuilder.Entity("Smsark.Models.Reservation", b =>
                {
                    b.Navigation("reservationItems");
                });

            modelBuilder.Entity("Smsark.Models.Room", b =>
                {
                    b.Navigation("Beds");
                });
#pragma warning restore 612, 618
        }
    }
}
