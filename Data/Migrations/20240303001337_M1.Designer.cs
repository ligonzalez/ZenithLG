﻿// <auto-generated />
using System;
using BooksOnLoan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksOnLoan.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240303001337_M1")]
    partial class M1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("BooksOnLoan.Models.Book", b =>
                {
                    b.Property<int>("CodeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("YearPublished")
                        .HasColumnType("INTEGER");

                    b.HasKey("CodeNumber");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            CodeNumber = 1,
                            Author = "Andrew Chevallier",
                            Quantity = 1,
                            Title = "Encyclopedia of Herbal Medicine: 550 Herbs and Remedies for Common Ailments",
                            YearPublished = 2016
                        },
                        new
                        {
                            CodeNumber = 2,
                            Author = "Michael T. Murray M.D. and Joseph Pizzorno",
                            Quantity = 3,
                            Title = "The Encyclopedia of Natural Medicine Third Edition",
                            YearPublished = 2012
                        },
                        new
                        {
                            CodeNumber = 3,
                            Author = "Thomas Easley and Steven Horne",
                            Quantity = 1,
                            Title = "The Modern Herbal Dispensatory: A Medicine-Making Guide",
                            YearPublished = 2016
                        },
                        new
                        {
                            CodeNumber = 4,
                            Author = "Cat Ellis",
                            Quantity = 2,
                            Title = "Prepper's Natural Medicine: Life-Saving Herbs, Essential Oils and Natural Remedies for When There is No Doctor",
                            YearPublished = 2015
                        },
                        new
                        {
                            CodeNumber = 5,
                            Author = "Rosemary Gladstar",
                            Quantity = 1,
                            Title = "Rosemary Gladstar's Medicinal Herbs: A Beginner's Guide: 33 Healing Herbs to Know, Grow, and Use",
                            YearPublished = 2012
                        });
                });

            modelBuilder.Entity("BooksOnLoan.Models.Transactions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<string>("AspNetUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CodeNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("CodeNumber");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e4603d95-7499-43ec-af70-eb850a180a19",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2df75bba-551d-437d-a812-d0533af7859c",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "7b1c5150-db56-4ba7-9946-721ad83eb941",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9a2fa2ea-ea1d-48c5-ae3f-196b0d9f3118",
                            Email = "aa@aa.aa",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "AA@AA.AA",
                            NormalizedUserName = "AA@AA.AA",
                            PasswordHash = "AQAAAAIAAYagAAAAEGN47FcC2vf4S5MvKmINXo4+QapHz0pgmp1oyR/90cX6KidE3In0J8UZb0i6ova2Mw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "988d515c-9d21-439b-85a0-d1738d607b8c",
                            TwoFactorEnabled = false,
                            UserName = "aa@aa.aa"
                        },
                        new
                        {
                            Id = "687e258d-5874-4667-8ac0-b95a0dae2882",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "901c8fb2-293e-4832-be64-9e4090c947e1",
                            Email = "mm@mm.mm",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MM@MM.MM",
                            NormalizedUserName = "MM@MM.MM",
                            PasswordHash = "AQAAAAIAAYagAAAAENYQK5G0RXxh5Nw35BkVvS6HFPdP9v3Od66lhUoU/Koc+Lwr+0OOmqVJ0KY9oh615A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c8cacb2c-4f68-4e2f-9da4-533904ae4d40",
                            TwoFactorEnabled = false,
                            UserName = "mm@mm.mm"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "7b1c5150-db56-4ba7-9946-721ad83eb941",
                            RoleId = "e4603d95-7499-43ec-af70-eb850a180a19"
                        },
                        new
                        {
                            UserId = "687e258d-5874-4667-8ac0-b95a0dae2882",
                            RoleId = "2df75bba-551d-437d-a812-d0533af7859c"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BooksOnLoan.Models.Transactions", b =>
                {
                    b.HasOne("BooksOnLoan.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("CodeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
