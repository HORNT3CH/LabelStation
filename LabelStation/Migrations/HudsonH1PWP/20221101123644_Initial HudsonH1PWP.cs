using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabelStation.Migrations.HudsonH1PWP
{
    public partial class InitialHudsonH1PWP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HudsonH1PWP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodePartA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePartB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePartC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintQty = table.Column<int>(type: "int", nullable: true),
                    MachineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HudsonH1PWP", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HudsonH1PWP");
        }
    }
}
