// <auto-generated />
using LabelStation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabelStation.Migrations.Kanban
{
    [DbContext(typeof(KanbanContext))]
    partial class KanbanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LabelStation.Models.Kanban", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BOMID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LineLimit")
                        .HasColumnType("int");

                    b.Property<string>("MachineNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderQty")
                        .HasColumnType("int");

                    b.Property<string>("ParentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentSKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Print")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrintQty")
                        .HasColumnType("int");

                    b.Property<int>("ReOrderQty")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Kanban");
                });
#pragma warning restore 612, 618
        }
    }
}
