﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UselessCore.Model;

namespace UselessCore.Migrations
{
    [DbContext(typeof(UselessContext))]
    [Migration("20190201204144_Auth1")]
    partial class Auth1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UselessCore.Model.Characters.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<int>("EntityStatus");

                    b.Property<int>("GameId");

                    b.Property<int?>("IconImageId");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ProfileImageId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("IconImageId");

                    b.HasIndex("ProfileImageId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("UselessCore.Model.Games.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<int>("EntityStatus");

                    b.Property<int?>("GameLogoId");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("GameLogoId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("UselessCore.Model.Images.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("EntityStatus");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasMaxLength(5000000);

                    b.Property<DateTime>("LastModified");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("UselessCore.Model.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UselessCore.Model.Characters.Character", b =>
                {
                    b.HasOne("UselessCore.Model.Games.Game", "Game")
                        .WithMany("Characters")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Images.Image", "IconImage")
                        .WithMany()
                        .HasForeignKey("IconImageId");

                    b.HasOne("UselessCore.Model.Images.Image", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId");
                });

            modelBuilder.Entity("UselessCore.Model.Games.Game", b =>
                {
                    b.HasOne("UselessCore.Model.Images.Image", "GameLogo")
                        .WithMany()
                        .HasForeignKey("GameLogoId");
                });
#pragma warning restore 612, 618
        }
    }
}
