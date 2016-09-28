using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFBirdData.Models;

namespace EFBirdData.Migrations
{
    [DbContext(typeof(EFBirdDbContext))]
    [Migration("20160926215307_AddBirdManagerUpdates")]
    partial class AddBirdManagerUpdates
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

                    b.Property<string>("ConservationCode");

                    b.Property<string>("ConservationStatus");

                    b.Property<string>("Family");

                    b.Property<double>("Length");

                    b.Property<string>("PrimaryColor");

                    b.Property<int?>("PrimaryColorId");

                    b.Property<string>("ScientificName");

                    b.Property<string>("SecondaryColor");

                    b.Property<int?>("SecondaryColorId");

                    b.Property<string>("Size");

                    b.Property<double>("Weight");

                    b.Property<double>("Width");

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

                    b.Property<string>("City");

                    b.Property<string>("Climate");

                    b.Property<string>("Country");

                    b.Property<string>("TerrainType");

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

                    b.Property<string>("ObserverLastName");

                    b.Property<int>("PlaceId");

                    b.Property<DateTime>("SightingDate");

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
                    b.HasOne("EFBirdData.Models.PrimaryColor")
                        .WithMany("Birds")
                        .HasForeignKey("PrimaryColorId");

                    b.HasOne("EFBirdData.Models.SecondaryColor")
                        .WithMany("Birds")
                        .HasForeignKey("SecondaryColorId");
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
