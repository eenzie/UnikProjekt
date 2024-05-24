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
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

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

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
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
