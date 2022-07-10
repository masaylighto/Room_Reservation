﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Room_Reservation_System.Infrastructure.Database.Context;

#nullable disable

namespace Room_Reservation_System.Web.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20220710092739_addowner")]
    partial class addowner
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Room_Reservation_System.Core.Entites.Reservation", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Begin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Room_Reservation_System.Core.Entites.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Counts")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Resources");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b10d231-a14e-42ae-89ce-d0e9308af831"),
                            Counts = 10L,
                            Name = "Tv",
                            RoomId = new Guid("792ba6aa-1416-482a-8f40-2557eb6a6368"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("62fa0598-a9bc-4840-ac26-8c45b25fabb0"),
                            Counts = 50L,
                            Name = "Chairs",
                            RoomId = new Guid("1faa2016-8d9d-4493-a7ce-4b2c9b0695b3"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("152b0678-a3d4-4813-a30e-6ff1883519ed"),
                            Counts = 50L,
                            Name = "Table",
                            RoomId = new Guid("0022b957-3413-4f87-9a03-7a7a4505ac9f"),
                            Type = 0
                        });
                });

            modelBuilder.Entity("Room_Reservation_System.Core.Entites.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("792ba6aa-1416-482a-8f40-2557eb6a6368"),
                            Capacity = 50,
                            Location = "Berlin",
                            RoomNumber = 512,
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("1faa2016-8d9d-4493-a7ce-4b2c9b0695b3"),
                            Capacity = 50,
                            Location = "Amsterdam",
                            RoomNumber = 522,
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("0022b957-3413-4f87-9a03-7a7a4505ac9f"),
                            Capacity = 50,
                            Location = "Berlin",
                            RoomNumber = 542,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Room_Reservation_System.Core.Entites.Reservation", b =>
                {
                    b.HasOne("Room_Reservation_System.Core.Entites.Room", "ReservedRoom")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReservedRoom");
                });

            modelBuilder.Entity("Room_Reservation_System.Core.Entites.Resource", b =>
                {
                    b.HasOne("Room_Reservation_System.Core.Entites.Room", "Room")
                        .WithMany("Resources")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Room_Reservation_System.Core.Entites.Room", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
