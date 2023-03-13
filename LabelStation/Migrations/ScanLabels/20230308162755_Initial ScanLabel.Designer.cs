﻿// <auto-generated />
using LabelStation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabelStation.Migrations.ScanLabels
{
    [DbContext(typeof(ScanLabelsContext))]
    [Migration("20230308162755_Initial ScanLabel")]
    partial class InitialScanLabel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LabelStation.Models.ScanLabel", b =>
                {
                    b.Property<int>("ScanLabelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScanLabelId"), 1L, 1);

                    b.Property<string>("ImageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrintLabel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScanLabelId");

                    b.ToTable("ScanLabel");
                });
#pragma warning restore 612, 618
        }
    }
}
