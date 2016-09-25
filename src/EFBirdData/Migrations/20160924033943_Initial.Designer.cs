using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFBirdData.Models;

namespace EFBirdData.Migrations
{
    [DbContext(typeof(EFBirdDbContext))]
    [Migration("20160924033943_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFBirdData.Models.Bird", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommonName");

                    b.Property<int>("PrimaryColorId");

                    b.Property<int>("SecondaryColorId");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryColorId");

                    b.HasIndex("SecondaryColorId");

                    b.ToTable("Birds");
                });

            modelBuilder.Entity("EFBirdData.Models.BirdsPlaces", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BirdId");

                    b.Property<int>("PlaceId");

                    b.HasKey("Id");

                    b.HasIndex("BirdId");

                    b.HasIndex("PlaceId");

                    b.ToTable("BirdsPlaces");
                });

            modelBuilder.Entity("EFBirdData.Models.BirdsTernaryColors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BirdId");

                    b.Property<int>("TernaryColorId");

                    b.HasKey("Id");

                    b.HasIndex("BirdId");

                    b.HasIndex("TernaryColorId");

                    b.ToTable("BirdsTernaryColors");
                });

            modelBuilder.Entity("EFBirdData.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("EFBirdData.Models.PrimaryColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PrimaryColors");
                });

            modelBuilder.Entity("EFBirdData.Models.SecondaryColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SecondaryColors");
                });

            modelBuilder.Entity("EFBirdData.Models.Sighting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BirdId");

                    b.Property<string>("ObserverFirstName");

                    b.Property<int>("PlaceId");

                    b.HasKey("Id");

                    b.HasIndex("BirdId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Sightings");
                });

            modelBuilder.Entity("EFBirdData.Models.TernaryColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TernaryColors");
                });

            modelBuilder.Entity("EFBirdData.Models.Bird", b =>
                {
                    b.HasOne("EFBirdData.Models.PrimaryColor", "PrimaryColor")
                        .WithMany("Birds")
                        .HasForeignKey("PrimaryColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFBirdData.Models.SecondaryColor", "SecondaryColor")
                        .WithMany("Birds")
                        .HasForeignKey("SecondaryColorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFBirdData.Models.BirdsPlaces", b =>
                {
                    b.HasOne("EFBirdData.Models.Bird", "Bird")
                        .WithMany("Habitats")
                        .HasForeignKey("BirdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFBirdData.Models.Place", "Place")
                        .WithMany("Habitats")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFBirdData.Models.BirdsTernaryColors", b =>
                {
                    b.HasOne("EFBirdData.Models.Bird", "Bird")
                        .WithMany("BirdsTernaryColors")
                        .HasForeignKey("BirdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFBirdData.Models.TernaryColor", "TernaryColor")
                        .WithMany("BirdsTernaryColors")
                        .HasForeignKey("TernaryColorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFBirdData.Models.Sighting", b =>
                {
                    b.HasOne("EFBirdData.Models.Bird", "Bird")
                        .WithMany("Sightings")
                        .HasForeignKey("BirdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFBirdData.Models.Place", "Place")
                        .WithMany("Sightings")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
