using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabelStation.Migrations.ScanLabels
{
    public partial class InitialScanLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScanLabel",
                columns: table => new
                {
                    ScanLabelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanLabel", x => x.ScanLabelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScanLabel");
        }
    }
}
