﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(CarsContext))]
    partial class CarsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Color");

                    b.Property<long>("IdBrand")
                        .HasColumnType("bigint")
                        .HasColumnName("IdBrand");

                    b.Property<long>("IdModel")
                        .HasColumnType("bigint")
                        .HasColumnName("IdModel");

                    b.Property<int>("Mileage")
                        .HasColumnType("int")
                        .HasColumnName("Mileage");

                    b.Property<double?>("Price")
                        .HasColumnType("double")
                        .HasColumnName("Price");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("VIN");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("Year");

                    b.HasKey("Id");

                    b.HasIndex("IdBrand");

                    b.HasIndex("IdModel");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Model", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("IdBrand")
                        .HasColumnType("bigint")
                        .HasColumnName("IdBrand");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("IdBrand");

                    b.ToTable("Models", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Car", b =>
                {
                    b.HasOne("Domain.Models.Brand", "BrandNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("IdBrand")
                        .IsRequired()
                        .HasConstraintName("FK_Cars_Brands");

                    b.HasOne("Domain.Models.Model", "ModelNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("IdModel")
                        .IsRequired()
                        .HasConstraintName("FK_Cars_Models");

                    b.Navigation("BrandNavigation");

                    b.Navigation("ModelNavigation");
                });

            modelBuilder.Entity("Domain.Models.Model", b =>
                {
                    b.HasOne("Domain.Models.Brand", "BrandNavigation")
                        .WithMany("Models")
                        .HasForeignKey("IdBrand")
                        .IsRequired()
                        .HasConstraintName("FK_Models_Brands");

                    b.Navigation("BrandNavigation");
                });

            modelBuilder.Entity("Domain.Models.Brand", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("Domain.Models.Model", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
