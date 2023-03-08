﻿// <auto-generated />
using LabelStation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabelStation.Migrations.SkuCards
{
    [DbContext(typeof(SkuCardsContext))]
    [Migration("20230303202731_Initial SkuCard")]
    partial class InitialSkuCard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LabelStation.Models.SkuCard", b =>
                {
                    b.Property<int>("SkuCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkuCardId"), 1L, 1);

                    b.Property<string>("ItemNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkuCardId");

                    b.ToTable("SkuCard");
                });
#pragma warning restore 612, 618
        }
    }
}