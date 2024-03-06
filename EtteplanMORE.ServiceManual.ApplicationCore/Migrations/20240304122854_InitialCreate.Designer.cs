﻿// <auto-generated />
using System;
using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EtteplanMORE.ServiceManual.ApplicationCore.Migrations
{
    [DbContext(typeof(ServiceManualDbContext))]
    [Migration("20240304122854_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EtteplanMORE.ServiceManual.ApplicationCore.Entities.FactoryDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FactoryDevices");
                });

            modelBuilder.Entity("EtteplanMORE.ServiceManual.ApplicationCore.Entities.MaintenanceTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FactoryDeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FactoryDeviceId");

                    b.ToTable("MaintenanceTasks");
                });

            modelBuilder.Entity("EtteplanMORE.ServiceManual.ApplicationCore.Entities.MaintenanceTask", b =>
                {
                    b.HasOne("EtteplanMORE.ServiceManual.ApplicationCore.Entities.FactoryDevice", "FactoryDevice")
                        .WithMany()
                        .HasForeignKey("FactoryDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FactoryDevice");
                });
#pragma warning restore 612, 618
        }
    }
}