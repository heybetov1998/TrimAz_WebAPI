using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class changed_field_names_of_location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoordinateY",
                table: "Locations",
                newName: "Longtitude");

            migrationBuilder.RenameColumn(
                name: "CoordinateX",
                table: "Locations",
                newName: "Latitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longtitude",
                table: "Locations",
                newName: "CoordinateY");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Locations",
                newName: "CoordinateX");
        }
    }
}
