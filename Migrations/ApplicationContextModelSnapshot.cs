﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie_Hunter_FinalProject.Areas.Identity.Data;

#nullable disable

namespace Movie_Hunter_FinalProject.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentMethod_Id")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("Plan_Id")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.Episodes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Episode_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("duration")
                        .HasColumnType("float");

                    b.Property<int>("season")
                        .HasColumnType("int");

                    b.Property<int>("series_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("series_id");

                    b.ToTable("episodes");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.LookUpTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LookUpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("lookUpTables");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.LookUpValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("lookupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("lookupId");

                    b.ToTable("lookUpValues");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.Movies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Movie_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Thumbnail_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Category_Id");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.Series", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeasons")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Thumbnail_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer_Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Category_Id");

                    b.ToTable("series");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.UserEpisodes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool?>("AddToFavorite")
                        .HasColumnType("bit");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Watched")
                        .HasColumnType("bit");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("EpisodeId");

                    b.HasIndex("user_id");

                    b.ToTable("userEpisodes");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.UserMovies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool?>("AddToFavorite")
                        .HasColumnType("bit");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Watched")
                        .HasColumnType("bit");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("MovieId");

                    b.HasIndex("user_id");

                    b.ToTable("userMovies");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.UserSeries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool?>("AddToFavorite")
                        .HasColumnType("bit");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.Property<bool?>("Watched")
                        .HasColumnType("bit");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("SeriesId");

                    b.HasIndex("user_id");

                    b.ToTable("userSeries");
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
                    b.HasOne("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", null)
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

                    b.HasOne("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Models.LookUpValues", "lookUpValues")
                        .WithMany("Users")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("lookUpValues");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.Episodes", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Models.Series", "series")
                        .WithMany()
                        .HasForeignKey("series_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("series");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.LookUpValues", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Models.LookUpTable", "lookUpTable")
                        .WithMany("lookUpValues")
                        .HasForeignKey("lookupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lookUpTable");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.Movies", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Models.LookUpValues", "lookUpValues")
                        .WithMany()
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lookUpValues");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.Series", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Models.LookUpValues", "lookUpValues")
                        .WithMany()
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lookUpValues");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.UserEpisodes", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Models.Episodes", "episodes")
                        .WithMany("userEpisodes")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", "systemUser")
                        .WithMany("userEpisodes")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("episodes");

                    b.Navigation("systemUser");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.UserMovies", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Models.Movies", "movies")
                        .WithMany("userMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", "systemUser")
                        .WithMany("userMovies")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movies");

                    b.Navigation("systemUser");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.UserSeries", b =>
                {
                    b.HasOne("Movie_Hunter_FinalProject.Models.Series", "series")
                        .WithMany("userSeries")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", "systemUser")
                        .WithMany("userSeries")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("series");

                    b.Navigation("systemUser");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Areas.Identity.Data.SystemUser", b =>
                {
                    b.Navigation("userEpisodes");

                    b.Navigation("userMovies");

                    b.Navigation("userSeries");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.Episodes", b =>
                {
                    b.Navigation("userEpisodes");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.LookUpTable", b =>
                {
                    b.Navigation("lookUpValues");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.LookUpValues", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.Movies", b =>
                {
                    b.Navigation("userMovies");
                });

            modelBuilder.Entity("Movie_Hunter_FinalProject.Models.Series", b =>
                {
                    b.Navigation("userSeries");
                });
#pragma warning restore 612, 618
        }
    }
}
