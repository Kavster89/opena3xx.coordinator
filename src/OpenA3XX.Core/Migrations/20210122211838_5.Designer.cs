﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenA3XX.Coordinator.TestHarness;
using OpenA3XX.Core.DataContexts;

namespace OpenA3XX.Coordinator.TestHarness.Migrations
{
    [DbContext(typeof(CoreDataContext))]
    [Migration("20210122211838_5")]
    partial class _5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("OpenA3XX.Core.Models.AircraftModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ManufucturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ManufucturerId");

                    b.ToTable("AircraftModels");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HardwareInputTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HardwarePanelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HardwareInputTypeId");

                    b.HasIndex("HardwarePanelId");

                    b.ToTable("HardwareInputs");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareInputType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HardwareInputType");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareOutput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HardwareOutputTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HardwarePanelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HardwareOutputTypeId");

                    b.HasIndex("HardwarePanelId");

                    b.ToTable("HardwareOutputs");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareOutputType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HardwareOutputType");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwarePanel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AircraftModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CockpitArea")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HardwarePanelOwner")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AircraftModelId");

                    b.ToTable("HardwarePanels");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.Manufucturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Manufucturers");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.AircraftModel", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.Manufucturer", "Manufucturer")
                        .WithMany("AircraftModels")
                        .HasForeignKey("ManufucturerId");

                    b.Navigation("Manufucturer");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareInput", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.HardwareInputType", "HardwareInputType")
                        .WithMany()
                        .HasForeignKey("HardwareInputTypeId");

                    b.HasOne("OpenA3XX.Core.Models.HardwarePanel", null)
                        .WithMany("HardwareInput")
                        .HasForeignKey("HardwarePanelId");

                    b.Navigation("HardwareInputType");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareOutput", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.HardwareOutputType", "HardwareOutputType")
                        .WithMany()
                        .HasForeignKey("HardwareOutputTypeId");

                    b.HasOne("OpenA3XX.Core.Models.HardwarePanel", null)
                        .WithMany("HardwareOutput")
                        .HasForeignKey("HardwarePanelId");

                    b.Navigation("HardwareOutputType");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwarePanel", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.AircraftModel", "AircraftModel")
                        .WithMany("HardwarePanels")
                        .HasForeignKey("AircraftModelId");

                    b.Navigation("AircraftModel");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.AircraftModel", b =>
                {
                    b.Navigation("HardwarePanels");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwarePanel", b =>
                {
                    b.Navigation("HardwareInput");

                    b.Navigation("HardwareOutput");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.Manufucturer", b =>
                {
                    b.Navigation("AircraftModels");
                });
#pragma warning restore 612, 618
        }
    }
}
