﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using assignment1.Data;

#nullable disable

namespace assignment1.Migrations
{
    [DbContext(typeof(BPMeasureContext))]
    partial class BPMeasureContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("assignment1.Models.BPMeasureModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Diastolic")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MeasurementDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Systolic")
                        .HasColumnType("TEXT");

                    b.Property<string>("positionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("positionId");

                    b.ToTable("BPMeasureModel");
                });

            modelBuilder.Entity("assignment1.Models.Position", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("assignment1.Models.BPMeasureModel", b =>
                {
                    b.HasOne("assignment1.Models.Position", "position")
                        .WithMany()
                        .HasForeignKey("positionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("position");
                });
#pragma warning restore 612, 618
        }
    }
}
