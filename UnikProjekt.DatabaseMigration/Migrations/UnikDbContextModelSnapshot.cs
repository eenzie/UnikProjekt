﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnikProjekt.Infrastructure.Database;

#nullable disable

namespace UnikProjekt.DatabaseMigration.Migrations
{
    [DbContext(typeof(UnikDbContext))]
    partial class UnikDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UnikProjekt.Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateBooked")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("SubTotal")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.BookingItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BookingTimeInMinutes")
                        .HasColumnType("int");

                    b.Property<decimal?>("Deposit")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.Property<TimeSpan>("IntervalEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("IntervalStart")
                        .HasColumnType("time");

                    b.Property<decimal>("Price")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeSlots")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BookingItems");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.BookingLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingEnd")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookingStart")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ItemPrice")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("BookingItemId");

                    b.ToTable("BookingLines");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("DocumentContent")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("DocumentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4a4f1a6b-9c38-4a64-91f8-37008dd9a6b4"),
                            RoleName = "Beboer"
                        },
                        new
                        {
                            Id = new Guid("5b5f2a7c-9d49-4b75-92f9-47019dd9b7c5"),
                            RoleName = "Menig"
                        },
                        new
                        {
                            Id = new Guid("6c6f3a8d-9e50-4c86-93fa-57020dd9c8d6"),
                            RoleName = "Sekretær"
                        },
                        new
                        {
                            Id = new Guid("7d7f4a9e-9f61-4d97-94fb-67031dd9d9e7"),
                            RoleName = "Kassér"
                        },
                        new
                        {
                            Id = new Guid("8e8f5aaf-a072-4ea8-95fc-77042ddaead8"),
                            RoleName = "Næstformand"
                        },
                        new
                        {
                            Id = new Guid("9f9f6ab0-b183-4fb9-96fd-87053ddbedf9"),
                            RoleName = "Formand"
                        });
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.Booking", b =>
                {
                    b.HasOne("UnikProjekt.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.BookingLine", b =>
                {
                    b.HasOne("UnikProjekt.Domain.Entities.Booking", null)
                        .WithMany("Items")
                        .HasForeignKey("BookingId");

                    b.HasOne("UnikProjekt.Domain.Entities.BookingItem", "BookingItem")
                        .WithMany()
                        .HasForeignKey("BookingItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingItem");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.Document", b =>
                {
                    b.HasOne("UnikProjekt.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.User", b =>
                {
                    b.OwnsOne("UnikProjekt.Domain.Value.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("UnikProjekt.Domain.Value.EmailAddress", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("UnikProjekt.Domain.Value.MobileNumber", "MobileNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("UnikProjekt.Domain.Value.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("MobileNumber")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("UnikProjekt.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnikProjekt.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("UnikProjekt.Domain.Value.RoleDates", "RoleDates", b1 =>
                        {
                            b1.Property<Guid>("UserRoleUserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("UserRoleRoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateOnly>("EndDate")
                                .HasColumnType("date");

                            b1.Property<DateOnly>("StartDate")
                                .HasColumnType("date");

                            b1.HasKey("UserRoleUserId", "UserRoleRoleId");

                            b1.ToTable("UserRoles");

                            b1.WithOwner()
                                .HasForeignKey("UserRoleUserId", "UserRoleRoleId");
                        });

                    b.Navigation("Role");

                    b.Navigation("RoleDates")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.Booking", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("UnikProjekt.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
