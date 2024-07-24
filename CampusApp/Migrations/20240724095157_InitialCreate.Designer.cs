﻿// <auto-generated />
using System;
using CampusApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CampusApp.Migrations
{
    [DbContext(typeof(CampusDbContext))]
    [Migration("20240724095157_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CampusApp.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "History"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Math"
                        },
                        new
                        {
                            Id = 3,
                            Name = "War"
                        });
                });

            modelBuilder.Entity("CampusApp.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnrolled")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(1022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ragnartheboss@gmail.com",
                            IsEnrolled = false,
                            LastName = "The Red",
                            Name = "Ragnar"
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1492, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "TheLioness78@gmail.com",
                            IsEnrolled = true,
                            LastName = "The Lioness",
                            Name = "Mjoll"
                        },
                        new
                        {
                            Id = 3,
                            Birthdate = new DateTime(1485, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "SecretBlade@yahoo.com",
                            IsEnrolled = false,
                            LastName = "The Blade",
                            Name = "Delphine"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
