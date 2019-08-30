﻿// <auto-generated />
using System;
using DotaApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotaApp.Data.Migrations
{
    [DbContext(typeof(DotaAppContext))]
    [Migration("20190829180754_CommentReviewColumns")]
    partial class CommentReviewColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotaApp.Data.DbModels.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AbilityName");

                    b.Property<string>("Behavior");

                    b.Property<string>("Cooldown");

                    b.Property<string>("DamageType");

                    b.Property<string>("Description");

                    b.Property<int>("HeroId");

                    b.Property<string>("Image");

                    b.Property<string>("ManaCost");

                    b.Property<string>("Pierce");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.AbilityAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AbilityId");

                    b.Property<bool>("Generated");

                    b.Property<string>("Header");

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.ToTable("AbilityAttributes");
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentMessage")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<bool>("IsApproved")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsPending")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int>("ItemId");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AgilityGain");

                    b.Property<int>("AttackRange");

                    b.Property<double>("AttackRate");

                    b.Property<string>("AttackType");

                    b.Property<int>("BaseAgility");

                    b.Property<double>("BaseArmor");

                    b.Property<int>("BaseAttackMax");

                    b.Property<int>("BaseAttackMin");

                    b.Property<int>("BaseHealth");

                    b.Property<double?>("BaseHealthRegen");

                    b.Property<int>("BaseIntellect");

                    b.Property<int>("BaseMana");

                    b.Property<double>("BaseManaRegen");

                    b.Property<int>("BaseMr");

                    b.Property<int>("BaseStrength");

                    b.Property<string>("Icon");

                    b.Property<string>("Image");

                    b.Property<double>("IntellectGain");

                    b.Property<int>("Legs");

                    b.Property<int>("MoveSpeed");

                    b.Property<string>("Name");

                    b.Property<string>("PrimaryAttribute");

                    b.Property<int>("ProjectileSpeed");

                    b.Property<double>("StrengthGain");

                    b.Property<double>("TurnRate");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.HeroRole", b =>
                {
                    b.Property<int>("HeroId");

                    b.Property<int>("RoleId");

                    b.HasKey("HeroId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("HeroRole");
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.IdentityRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("IdentityRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost");

                    b.Property<string>("Image");

                    b.Property<string>("Lore");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.ItemAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Footer");

                    b.Property<string>("Header");

                    b.Property<int>("ItemId");

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemAttributes");
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@dota.app",
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 245, 143, 157, 194, 124, 5, 196, 92, 82, 12, 49, 125, 116, 122, 93, 196, 173, 155, 223, 184, 74, 213, 176, 57, 126, 192, 184, 114, 238, 125, 184, 27, 161, 19, 96, 93, 189, 192, 48, 85, 149, 236, 96, 132, 185, 160, 20, 71, 12, 68, 240, 60, 86, 54, 131, 228, 179, 163, 180, 63, 38, 116, 10, 69 },
                            PasswordSalt = new byte[] { 103, 26, 148, 69, 144, 80, 209, 196, 195, 68, 127, 41, 169, 30, 9, 158, 122, 122, 56, 115, 84, 66, 77, 54, 67, 85, 14, 203, 141, 217, 175, 82, 55, 185, 39, 226, 213, 196, 9, 84, 73, 126, 24, 151, 66, 73, 240, 200, 97, 19, 129, 197, 18, 103, 160, 106, 140, 160, 95, 70, 36, 183, 65, 34, 232, 85, 163, 30, 37, 43, 31, 117, 74, 10, 111, 18, 118, 81, 180, 38, 60, 246, 1, 178, 109, 147, 119, 63, 64, 0, 61, 108, 18, 49, 212, 65, 96, 75, 177, 116, 208, 164, 112, 254, 99, 185, 144, 101, 12, 14, 139, 59, 226, 89, 185, 174, 80, 247, 7, 167, 156, 39, 249, 59, 192, 158, 106, 80 },
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.Ability", b =>
                {
                    b.HasOne("DotaApp.Data.DbModels.Hero", "Hero")
                        .WithMany("Abilities")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.AbilityAttribute", b =>
                {
                    b.HasOne("DotaApp.Data.DbModels.Ability", "Ability")
                        .WithMany("AbilityAttributes")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.Comment", b =>
                {
                    b.HasOne("DotaApp.Data.DbModels.Item", "Item")
                        .WithMany("Comments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.HeroRole", b =>
                {
                    b.HasOne("DotaApp.Data.DbModels.Hero", "Hero")
                        .WithMany("Roles")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotaApp.Data.DbModels.Role", "Role")
                        .WithMany("Heroes")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.ItemAttribute", b =>
                {
                    b.HasOne("DotaApp.Data.DbModels.Item", "Item")
                        .WithMany("ItemAttributes")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DotaApp.Data.DbModels.UserRole", b =>
                {
                    b.HasOne("DotaApp.Data.DbModels.IdentityRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotaApp.Data.DbModels.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}