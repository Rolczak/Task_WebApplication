﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZadanieRekrutacja.DataAccess.Data;

namespace ZadanieRekrutacja.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20200527135052_AddEmployeeToDb")]
    partial class AddEmployeeToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZadanieRekrutacja.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerformanceManagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerformanceManagerId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HireDate = new DateTime(2015, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Anna"
                        },
                        new
                        {
                            Id = 2,
                            HireDate = new DateTime(2012, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jan",
                            PerformanceManagerId = 1
                        },
                        new
                        {
                            Id = 3,
                            HireDate = new DateTime(2018, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andrzej",
                            PerformanceManagerId = 1
                        },
                        new
                        {
                            Id = 4,
                            HireDate = new DateTime(2010, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Piotr",
                            PerformanceManagerId = 2
                        },
                        new
                        {
                            Id = 5,
                            HireDate = new DateTime(2011, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Katarzyna",
                            PerformanceManagerId = 2
                        },
                        new
                        {
                            Id = 6,
                            HireDate = new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Barbara",
                            PerformanceManagerId = 2
                        },
                        new
                        {
                            Id = 7,
                            HireDate = new DateTime(2015, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ewa",
                            PerformanceManagerId = 4
                        },
                        new
                        {
                            Id = 8,
                            HireDate = new DateTime(2009, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Zofia",
                            PerformanceManagerId = 2
                        },
                        new
                        {
                            Id = 9,
                            HireDate = new DateTime(2018, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Marian",
                            PerformanceManagerId = 5
                        },
                        new
                        {
                            Id = 10,
                            HireDate = new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Michał",
                            PerformanceManagerId = 3
                        },
                        new
                        {
                            Id = 11,
                            HireDate = new DateTime(2013, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Mateusz"
                        },
                        new
                        {
                            Id = 12,
                            HireDate = new DateTime(2017, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Wiesław"
                        },
                        new
                        {
                            Id = 13,
                            HireDate = new DateTime(2013, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Edyta",
                            PerformanceManagerId = 10
                        },
                        new
                        {
                            Id = 14,
                            HireDate = new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Patrycja",
                            PerformanceManagerId = 10
                        },
                        new
                        {
                            Id = 15,
                            HireDate = new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tomasz",
                            PerformanceManagerId = 10
                        });
                });

            modelBuilder.Entity("ZadanieRekrutacja.Models.Employee", b =>
                {
                    b.HasOne("ZadanieRekrutacja.Models.Employee", "PerformanceManager")
                        .WithMany()
                        .HasForeignKey("PerformanceManagerId");
                });
#pragma warning restore 612, 618
        }
    }
}
