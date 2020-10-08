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
    [Migration("20191027205329_18_enumSection")]
    partial class _18_enumSection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("UselessCore.Model.Characters.Fighter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FighterTestField");

                    b.Property<int>("GameId");

                    b.Property<int?>("IconImageId");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("IconImageId");

                    b.ToTable("Fighters");
                });

            modelBuilder.Entity("UselessCore.Model.Characters.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("GameId");

                    b.Property<int?>("IconImageId");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("MobaTestField");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("IconImageId");

                    b.ToTable("Heros");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.CharacterTierEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("CharacterTierEntry<Fighter>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.CharacterTierEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("CharacterTierEntry<Hero>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.CounteredByCharacterLinkEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedCharacterId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedCharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("CounteredByCharacterLinkEntry<Fighter>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.CounteredByCharacterLinkEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedCharacterId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedCharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("CounteredByCharacterLinkEntry<Hero>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.MainCharacterTagEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedTagId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedTagId");

                    b.HasIndex("UserId");

                    b.ToTable("MainCharacterTagEntry<Fighter>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.MainCharacterTagEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedTagId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedTagId");

                    b.HasIndex("UserId");

                    b.ToTable("MainCharacterTagEntry<Hero>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.SimilarToInGameCharacterLinkEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedCharacterId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedCharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("SimilarToInGameCharacterLinkEntry<Fighter>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.SimilarToInGameCharacterLinkEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedCharacterId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedCharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("SimilarToInGameCharacterLinkEntry<Hero>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.SimilarToInGenreCharacterLinkEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedCharacterId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedCharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("SimilarToInGenreCharacterLinkEntry<Fighter>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.SimilarToInGenreCharacterLinkEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedCharacterId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedCharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("SimilarToInGenreCharacterLinkEntry<Hero>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.StrongAgainstCharacterLinkEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedCharacterId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedCharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("StrongAgainstCharacterLinkEntry<Fighter>");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.StrongAgainstCharacterLinkEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LinkedCharacterId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("LinkedCharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("StrongAgainstCharacterLinkEntry<Hero>");
                });

            modelBuilder.Entity("UselessCore.Model.Games.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("GameLogoId");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("GameLogoId");

                    b.ToTable("Games");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Game");
                });

            modelBuilder.Entity("UselessCore.Model.Images.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasMaxLength(5000000);

                    b.Property<DateTime>("LastModified");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("UselessCore.Model.Tags.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("UselessCore.Model.Users.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("UselessCore.Model.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int?>("AvatarIconId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("UselessCore.Model.Games.FightingGame", b =>
                {
                    b.HasBaseType("UselessCore.Model.Games.Game");

                    b.Property<string>("FighterTestField");

                    b.HasDiscriminator().HasValue("FightingGame");
                });

            modelBuilder.Entity("UselessCore.Model.Games.MOBA", b =>
                {
                    b.HasBaseType("UselessCore.Model.Games.Game");

                    b.Property<string>("MobaTestField");

                    b.HasDiscriminator().HasValue("MOBA");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("UselessCore.Model.Users.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("UselessCore.Model.Users.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("UselessCore.Model.Users.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("UselessCore.Model.Users.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Users.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("UselessCore.Model.Users.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Characters.Fighter", b =>
                {
                    b.HasOne("UselessCore.Model.Games.FightingGame", "Game")
                        .WithMany("Characters")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Images.Image", "IconImage")
                        .WithMany()
                        .HasForeignKey("IconImageId");
                });

            modelBuilder.Entity("UselessCore.Model.Characters.Hero", b =>
                {
                    b.HasOne("UselessCore.Model.Games.MOBA", "Game")
                        .WithMany("Characters")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Images.Image", "IconImage")
                        .WithMany()
                        .HasForeignKey("IconImageId");
                });

            modelBuilder.Entity("UselessCore.Model.Entries.CharacterTierEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Fighter", "Character")
                        .WithMany("CharacterTierEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.CharacterTierEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Hero", "Character")
                        .WithMany("CharacterTierEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.CounteredByCharacterLinkEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Fighter", "Character")
                        .WithMany("CounteredByCharactersInGenreEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Characters.Fighter", "LinkedCharacter")
                        .WithMany()
                        .HasForeignKey("LinkedCharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.CounteredByCharacterLinkEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Hero", "Character")
                        .WithMany("CounteredByCharactersInGenreEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Characters.Hero", "LinkedCharacter")
                        .WithMany()
                        .HasForeignKey("LinkedCharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.MainCharacterTagEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Fighter", "Character")
                        .WithMany("MainCharacterTagEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Tags.Tag", "LinkedTag")
                        .WithMany("MainFighterTagEntries")
                        .HasForeignKey("LinkedTagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.MainCharacterTagEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Hero", "Character")
                        .WithMany("MainCharacterTagEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Tags.Tag", "LinkedTag")
                        .WithMany("MainHeroTagEntries")
                        .HasForeignKey("LinkedTagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.SimilarToInGameCharacterLinkEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Fighter", "Character")
                        .WithMany("SimilarCharactersInGameEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Characters.Fighter", "LinkedCharacter")
                        .WithMany()
                        .HasForeignKey("LinkedCharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.SimilarToInGameCharacterLinkEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Hero", "Character")
                        .WithMany("SimilarCharactersInGameEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Characters.Hero", "LinkedCharacter")
                        .WithMany()
                        .HasForeignKey("LinkedCharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.SimilarToInGenreCharacterLinkEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Fighter", "Character")
                        .WithMany("SimilarCharactersInGenreEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Characters.Fighter", "LinkedCharacter")
                        .WithMany()
                        .HasForeignKey("LinkedCharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.SimilarToInGenreCharacterLinkEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Hero", "Character")
                        .WithMany("SimilarCharactersInGenreEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Characters.Hero", "LinkedCharacter")
                        .WithMany()
                        .HasForeignKey("LinkedCharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.StrongAgainstCharacterLinkEntry<UselessCore.Model.Characters.Fighter>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Fighter", "Character")
                        .WithMany("StrongAgainstCharactersInGenreEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Characters.Fighter", "LinkedCharacter")
                        .WithMany()
                        .HasForeignKey("LinkedCharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UselessCore.Model.Entries.StrongAgainstCharacterLinkEntry<UselessCore.Model.Characters.Hero>", b =>
                {
                    b.HasOne("UselessCore.Model.Characters.Hero", "Character")
                        .WithMany("StrongAgainstCharactersInGenreEntries")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UselessCore.Model.Characters.Hero", "LinkedCharacter")
                        .WithMany()
                        .HasForeignKey("LinkedCharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UselessCore.Model.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
