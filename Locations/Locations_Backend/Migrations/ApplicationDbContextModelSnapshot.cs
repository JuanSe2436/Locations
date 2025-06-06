﻿// <auto-generated />
using Locations_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Locations_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LocalTypes");
                });

            modelBuilder.Entity("Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<int>("LocalStateId")
                        .HasColumnType("int");

                    b.Property<int>("LocalTypeId")
                        .HasColumnType("int");

                    b.Property<int>("LocalityId")
                        .HasColumnType("int");

                    b.Property<int>("LocationClassId")
                        .HasColumnType("int");

                    b.Property<string>("LocationNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SquareMeters")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocalStateId");

                    b.HasIndex("LocalTypeId");

                    b.HasIndex("LocalityId");

                    b.HasIndex("LocationClassId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Locations.Shared.Models.LocalState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LocalStates");
                });

            modelBuilder.Entity("Locations.Shared.Models.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Locations.Shared.Models.LocationClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LocationClasses");
                });

            modelBuilder.Entity("Location", b =>
                {
                    b.HasOne("Locations.Shared.Models.LocalState", "LocalState")
                        .WithMany("Locations")
                        .HasForeignKey("LocalStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalType", "LocalType")
                        .WithMany("Locations")
                        .HasForeignKey("LocalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locations.Shared.Models.Locality", "Locality")
                        .WithMany("Locations")
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locations.Shared.Models.LocationClass", "LocationClass")
                        .WithMany("Locations")
                        .HasForeignKey("LocationClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalState");

                    b.Navigation("LocalType");

                    b.Navigation("Locality");

                    b.Navigation("LocationClass");
                });

            modelBuilder.Entity("LocalType", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Locations.Shared.Models.LocalState", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Locations.Shared.Models.Locality", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Locations.Shared.Models.LocationClass", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
