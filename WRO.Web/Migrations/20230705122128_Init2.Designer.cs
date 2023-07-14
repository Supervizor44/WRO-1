﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WRO.Web.Data.Contexts;

#nullable disable

namespace WRO.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230705122128_Init2")]
    partial class Init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.ContactUs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FacebookLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InstagramLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.ContestCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContestCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("23583547-56a0-4176-9603-133dec1a402f"),
                            Name = "Robomission - Elementary(8 - 12)"
                        },
                        new
                        {
                            Id = new Guid("74896a87-1e98-4dd7-814a-f85362676f52"),
                            Name = "Robomission - Junior(11 - 15)"
                        },
                        new
                        {
                            Id = new Guid("fc048f37-45b3-4c6b-baa8-b5b0c5b9b6ce"),
                            Name = "Robomission - Senior(14 - 19)"
                        },
                        new
                        {
                            Id = new Guid("8320e149-0971-4630-ace4-08e471d18064"),
                            Name = "Future Innovators - Elementary(8 - 12)"
                        },
                        new
                        {
                            Id = new Guid("d8f0f079-7401-45ba-b918-6d1b566e527f"),
                            Name = "Future Innovators - Junior(11 - 15)"
                        },
                        new
                        {
                            Id = new Guid("14659459-7a79-4b15-9532-968a9512fcf3"),
                            Name = "Future Innovators - Senior(14 - 19)"
                        },
                        new
                        {
                            Id = new Guid("c0a4af27-0ab0-4212-8a94-188f6a6dac6a"),
                            Name = "Robosports(11 - 19)"
                        },
                        new
                        {
                            Id = new Guid("f51485e9-e9c1-491c-a03e-20194d89f7a3"),
                            Name = "Future Engineers(14 - 19)"
                        });
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.IdentityAggregate.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.ImageAggregate.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Image");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.NewsAggregate.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.NewsAggregate.NewsContext", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Culture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.ToTable("NewsContexts");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.RegistrantAggregate.Judge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BankRekvizit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ContestCategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdSerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StartupExperince")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WroExperince")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContestCategoryId");

                    b.ToTable("Judges");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.RegistrantAggregate.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContestCategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsWinner")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TeamCoachId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ContestCategoryId");

                    b.HasIndex("TeamCoachId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.RegistrantAggregate.TeamCoach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdSerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TeamCoaches");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.RegistrantAggregate.TeamMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdSerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Instuition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.RegistrantAggregate.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdSerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KnownForeignLanguages")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfessionAtUniversity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VolunteerExperience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.IdentityAggregate.Admin", b =>
                {
                    b.HasBaseType("WRO.Web.Data.Entities.IdentityAggregate.AppUser");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = new Guid("939e6e06-b9bf-4eee-926b-dc00c908762c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d2d4b0fd-1887-4c80-b292-0d7b88ee095f",
                            Email = "admin@wro.az",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@WRO.AZ",
                            NormalizedUserName = "ADMIN@WRO.AZ",
                            PasswordHash = "AQAAAAEAACcQAAAAEGGBBBnibETEbCkw/QivohTJLpFlHXbeUSAJ955v0Hh2cjKxtU6dtbHU2Lccy+nozg==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "fe4dd35e-69a2-4a30-953d-40d4522fb77c",
                            TwoFactorEnabled = false,
                            UserName = "admin@wro.az"
                        });
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.ImageAggregate.GalleryImage", b =>
                {
                    b.HasBaseType("WRO.Web.Data.Entities.ImageAggregate.Image");

                    b.Property<int>("Season")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("GalleryImage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("WRO.Web.Data.Entities.IdentityAggregate.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("WRO.Web.Data.Entities.IdentityAggregate.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WRO.Web.Data.Entities.IdentityAggregate.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("WRO.Web.Data.Entities.IdentityAggregate.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.NewsAggregate.News", b =>
                {
                    b.HasOne("WRO.Web.Data.Entities.ImageAggregate.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.NewsAggregate.NewsContext", b =>
                {
                    b.HasOne("WRO.Web.Data.Entities.NewsAggregate.News", "News")
                        .WithMany("Contexts")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.RegistrantAggregate.Judge", b =>
                {
                    b.HasOne("WRO.Web.Data.Entities.ContestCategory", "ContestCategory")
                        .WithMany()
                        .HasForeignKey("ContestCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContestCategory");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.RegistrantAggregate.Team", b =>
                {
                    b.HasOne("WRO.Web.Data.Entities.ContestCategory", "ContestCategory")
                        .WithMany()
                        .HasForeignKey("ContestCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WRO.Web.Data.Entities.RegistrantAggregate.TeamCoach", "TeamCoach")
                        .WithMany()
                        .HasForeignKey("TeamCoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContestCategory");

                    b.Navigation("TeamCoach");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.RegistrantAggregate.TeamMember", b =>
                {
                    b.HasOne("WRO.Web.Data.Entities.RegistrantAggregate.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.NewsAggregate.News", b =>
                {
                    b.Navigation("Contexts");
                });

            modelBuilder.Entity("WRO.Web.Data.Entities.RegistrantAggregate.Team", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
