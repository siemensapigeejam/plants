using Microsoft.EntityFrameworkCore.Migrations;

namespace DESPortal.Infrastructure.Migrations
{
    public partial class AddedCoortinatesToPlant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Plants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Plants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Plants");
        }
    }
}
