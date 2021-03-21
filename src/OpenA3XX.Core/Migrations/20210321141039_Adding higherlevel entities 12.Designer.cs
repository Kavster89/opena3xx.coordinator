﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenA3XX.Core.DataContexts;

namespace OpenA3XX.Coordinator.TestHarness.Migrations
{
    [DbContext(typeof(CoreDataContext))]
    [Migration("20210321141039_Adding higherlevel entities 12")]
    partial class Addinghigherlevelentities12
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

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("AircraftModels");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HardwareBoards");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HardwareInputTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HardwarePanelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HardwareInputTypeId");

                    b.HasIndex("HardwarePanelId");

                    b.ToTable("HardwareInputs");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareInputSelector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HardwareInputId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SimulatorEventId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HardwareInputId");

                    b.HasIndex("SimulatorEventId");

                    b.ToTable("HardwareInputSelectors");
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

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareOutputSelector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HardwareOutputId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HardwareOutputId");

                    b.ToTable("HardwareOutputSelectors");
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

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwarePanelToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeviceIpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeviceToken")
                        .HasColumnType("TEXT");

                    b.Property<int>("HardwarePanelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HardwarePanelId");

                    b.ToTable("HardwarePanelTokens");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.IOExtenderBit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExtenderBusBitType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HardwareBit")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HardwareInputSelectorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HardwareOutputSelectorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IOExtenderBusId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HardwareInputSelectorId");

                    b.HasIndex("HardwareOutputSelectorId");

                    b.HasIndex("IOExtenderBusId");

                    b.ToTable("IOExtenderBits");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.IOExtenderBus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HardwareBoardId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HardwareBus")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HardwareBoardId");

                    b.ToTable("IOExtenderBuses");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.SimulatorEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FriendlyName")
                        .HasColumnType("TEXT");

                    b.Property<int>("SimulatorEventSdkType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SimulatorEventType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SimulatorSoftware")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SimulatorEvents");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.SystemConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SystemConfiguration");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.AircraftModel", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.Manufacturer", "Manufacturer")
                        .WithMany("AircraftModels")
                        .HasForeignKey("ManufacturerId");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareInput", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.HardwareInputType", "HardwareInputType")
                        .WithMany()
                        .HasForeignKey("HardwareInputTypeId");

                    b.HasOne("OpenA3XX.Core.Models.HardwarePanel", "HardwarePanel")
                        .WithMany("HardwareInput")
                        .HasForeignKey("HardwarePanelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HardwareInputType");

                    b.Navigation("HardwarePanel");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareInputSelector", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.HardwareInput", "HardwareInput")
                        .WithMany("HardwareInputSelectorList")
                        .HasForeignKey("HardwareInputId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenA3XX.Core.Models.SimulatorEvent", "SimulatorEvent")
                        .WithMany()
                        .HasForeignKey("SimulatorEventId");

                    b.Navigation("HardwareInput");

                    b.Navigation("SimulatorEvent");
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

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareOutputSelector", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.HardwareOutput", "HardwareOutput")
                        .WithMany("HardwareOutputSelectorList")
                        .HasForeignKey("HardwareOutputId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HardwareOutput");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwarePanel", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.AircraftModel", "AircraftModel")
                        .WithMany("HardwarePanels")
                        .HasForeignKey("AircraftModelId");

                    b.Navigation("AircraftModel");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwarePanelToken", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.HardwarePanel", "HardwarePanel")
                        .WithMany()
                        .HasForeignKey("HardwarePanelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HardwarePanel");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.IOExtenderBit", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.HardwareInputSelector", "HardwareInputSelector")
                        .WithMany()
                        .HasForeignKey("HardwareInputSelectorId");

                    b.HasOne("OpenA3XX.Core.Models.HardwareOutputSelector", "HardwareOutputSelector")
                        .WithMany()
                        .HasForeignKey("HardwareOutputSelectorId");

                    b.HasOne("OpenA3XX.Core.Models.IOExtenderBus", "IOExtenderBus")
                        .WithMany("Bits")
                        .HasForeignKey("IOExtenderBusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HardwareInputSelector");

                    b.Navigation("HardwareOutputSelector");

                    b.Navigation("IOExtenderBus");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.IOExtenderBus", b =>
                {
                    b.HasOne("OpenA3XX.Core.Models.HardwareBoard", "HardwareBoard")
                        .WithMany("Buses")
                        .HasForeignKey("HardwareBoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HardwareBoard");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.AircraftModel", b =>
                {
                    b.Navigation("HardwarePanels");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareBoard", b =>
                {
                    b.Navigation("Buses");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareInput", b =>
                {
                    b.Navigation("HardwareInputSelectorList");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwareOutput", b =>
                {
                    b.Navigation("HardwareOutputSelectorList");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.HardwarePanel", b =>
                {
                    b.Navigation("HardwareInput");

                    b.Navigation("HardwareOutput");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.IOExtenderBus", b =>
                {
                    b.Navigation("Bits");
                });

            modelBuilder.Entity("OpenA3XX.Core.Models.Manufacturer", b =>
                {
                    b.Navigation("AircraftModels");
                });
#pragma warning restore 612, 618
        }
    }
}
