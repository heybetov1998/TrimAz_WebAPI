using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class locations_and_barbershop_relations_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Barbershops_BarbershopId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_BarbershopId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "BarbershopId",
                table: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Barbershops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BarbershopLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarbershopId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarbershopLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarbershopLocation_Barbershops_BarbershopId",
                        column: x => x.BarbershopId,
                        principalTable: "Barbershops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarbershopLocation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarbershopLocation_BarbershopId",
                table: "BarbershopLocation",
                column: "BarbershopId");

            migrationBuilder.CreateIndex(
                name: "IX_BarbershopLocation_LocationId",
                table: "BarbershopLocation",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarbershopLocation");

            migrationBuilder.AddColumn<int>(
                name: "BarbershopId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Barbershops",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_BarbershopId",
                table: "Locations",
                column: "BarbershopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Barbershops_BarbershopId",
                table: "Locations",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
