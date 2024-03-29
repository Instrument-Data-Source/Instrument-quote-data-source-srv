﻿// <auto-generated />
using System;
using Instrument.Quote.Source.Configuration.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Instrument.Quote.Source.Configuration.DataBase.Migrations
{
    [DbContext(typeof(SrvDbContext))]
    [Migration("20230727061710_RenameColumnFullCalc")]
    partial class RenameColumnFullCalc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.ChartAggregate.Model.Candle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChartId")
                        .HasColumnType("integer");

                    b.Property<int>("Close")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("High")
                        .HasColumnType("integer");

                    b.Property<int>("Low")
                        .HasColumnType("integer");

                    b.Property<int>("Open")
                        .HasColumnType("integer");

                    b.Property<int>("Volume")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChartId", "DateTime")
                        .IsUnique();

                    b.ToTable("Candles");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.ChartAggregate.Model.Chart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("InstrumentId")
                        .HasColumnType("integer");

                    b.Property<int>("TimeFrameId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UntillDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("TimeFrameId");

                    b.HasIndex("InstrumentId", "TimeFrameId")
                        .IsUnique();

                    b.ToTable("Charts");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.InstrumentAggregate.Model.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int>("InstrumentTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte>("PriceDecimalLen")
                        .HasColumnType("smallint");

                    b.Property<byte>("VolumeDecimalLen")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("InstrumentTypeId");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.InstrumentAggregate.Model.InstrumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.ToTable("InstrumentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Currency"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Stock"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CryptoCurrency"
                        });
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.JoinedChartAggregate.Model.JoinedCandle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Close")
                        .HasColumnType("integer");

                    b.Property<int>("High")
                        .HasColumnType("integer");

                    b.Property<bool>("IsFullCalc")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLast")
                        .HasColumnType("boolean");

                    b.Property<int>("JoinedChartId")
                        .HasColumnType("integer");

                    b.Property<int>("Low")
                        .HasColumnType("integer");

                    b.Property<int>("Open")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StepDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TargetDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Volume")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("JoinedChartId", "StepDateTime")
                        .IsUnique();

                    b.ToTable("JoinedCandles");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.JoinedChartAggregate.Model.JoinedChart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StepChartId")
                        .HasColumnType("integer");

                    b.Property<int>("TargetTimeFrameId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UntillDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("TargetTimeFrameId");

                    b.HasIndex("StepChartId", "TargetTimeFrameId")
                        .IsUnique();

                    b.ToTable("JoinedCharts");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.TimeFrameAggregate.Model.TimeFrame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<int>("Seconds")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TimeFrames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "M",
                            Seconds = 2592000
                        },
                        new
                        {
                            Id = 2,
                            Name = "W1",
                            Seconds = 604800
                        },
                        new
                        {
                            Id = 3,
                            Name = "D1",
                            Seconds = 86400
                        },
                        new
                        {
                            Id = 4,
                            Name = "H4",
                            Seconds = 14400
                        },
                        new
                        {
                            Id = 5,
                            Name = "H1",
                            Seconds = 3600
                        },
                        new
                        {
                            Id = 6,
                            Name = "m30",
                            Seconds = 1800
                        },
                        new
                        {
                            Id = 7,
                            Name = "m15",
                            Seconds = 900
                        },
                        new
                        {
                            Id = 8,
                            Name = "m10",
                            Seconds = 600
                        },
                        new
                        {
                            Id = 9,
                            Name = "m5",
                            Seconds = 300
                        },
                        new
                        {
                            Id = 10,
                            Name = "m1",
                            Seconds = 60
                        });
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.ChartAggregate.Model.Candle", b =>
                {
                    b.HasOne("Instrument.Quote.Source.App.Core.ChartAggregate.Model.Chart", "Chart")
                        .WithMany("Candles")
                        .HasForeignKey("ChartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chart");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.ChartAggregate.Model.Chart", b =>
                {
                    b.HasOne("Instrument.Quote.Source.App.Core.InstrumentAggregate.Model.Instrument", "Instrument")
                        .WithMany("Charts")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Instrument.Quote.Source.App.Core.TimeFrameAggregate.Model.TimeFrame", "TimeFrame")
                        .WithMany("Charts")
                        .HasForeignKey("TimeFrameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instrument");

                    b.Navigation("TimeFrame");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.InstrumentAggregate.Model.Instrument", b =>
                {
                    b.HasOne("Instrument.Quote.Source.App.Core.InstrumentAggregate.Model.InstrumentType", "InstrumentType")
                        .WithMany("Instruments")
                        .HasForeignKey("InstrumentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InstrumentType");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.JoinedChartAggregate.Model.JoinedCandle", b =>
                {
                    b.HasOne("Instrument.Quote.Source.App.Core.JoinedChartAggregate.Model.JoinedChart", "JoinedChart")
                        .WithMany("JoinedCandles")
                        .HasForeignKey("JoinedChartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JoinedChart");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.JoinedChartAggregate.Model.JoinedChart", b =>
                {
                    b.HasOne("Instrument.Quote.Source.App.Core.ChartAggregate.Model.Chart", "StepChart")
                        .WithMany("JoinedCharts")
                        .HasForeignKey("StepChartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Instrument.Quote.Source.App.Core.TimeFrameAggregate.Model.TimeFrame", "TargetTimeFrame")
                        .WithMany("JoinedCharts")
                        .HasForeignKey("TargetTimeFrameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StepChart");

                    b.Navigation("TargetTimeFrame");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.ChartAggregate.Model.Chart", b =>
                {
                    b.Navigation("Candles");

                    b.Navigation("JoinedCharts");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.InstrumentAggregate.Model.Instrument", b =>
                {
                    b.Navigation("Charts");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.InstrumentAggregate.Model.InstrumentType", b =>
                {
                    b.Navigation("Instruments");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.JoinedChartAggregate.Model.JoinedChart", b =>
                {
                    b.Navigation("JoinedCandles");
                });

            modelBuilder.Entity("Instrument.Quote.Source.App.Core.TimeFrameAggregate.Model.TimeFrame", b =>
                {
                    b.Navigation("Charts");

                    b.Navigation("JoinedCharts");
                });
#pragma warning restore 612, 618
        }
    }
}
