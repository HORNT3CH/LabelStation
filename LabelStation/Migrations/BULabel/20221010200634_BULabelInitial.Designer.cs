﻿// <auto-generated />
using LabelStation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabelStation.Migrations.BULabel
{
    [DbContext(typeof(BULabelContext))]
    [Migration("20221010200634_BULabelInitial")]
    partial class BULabelInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LabelStation.Models.BULabel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Print")
                        .HasColumnType("tinyint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Standard")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BULabel");
                });
#pragma warning restore 612, 618
        }
    }
}
