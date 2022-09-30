using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class updated_AppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberTime_Barbers_BarberId",
                table: "BarberTime");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberTime_Times_TimeId",
                table: "BarberTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberTime",
                table: "BarberTime");

            migrationBuilder.RenameTable(
                name: "BarberTime",
                newName: "BarberTimes");

            migrationBuilder.RenameIndex(
                name: "IX_BarberTime_TimeId",
                table: "BarberTimes",
                newName: "IX_BarberTimes_TimeId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberTime_BarberId",
                table: "BarberTimes",
                newName: "IX_BarberTimes_BarberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberTimes",
                table: "BarberTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberTimes_Barbers_BarberId",
                table: "BarberTimes",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberTimes_Times_TimeId",
                table: "BarberTimes",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberTimes_Barbers_BarberId",
                table: "BarberTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberTimes_Times_TimeId",
                table: "BarberTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberTimes",
                table: "BarberTimes");

            migrationBuilder.RenameTable(
                name: "BarberTimes",
                newName: "BarberTime");

            migrationBuilder.RenameIndex(
                name: "IX_BarberTimes_TimeId",
                table: "BarberTime",
                newName: "IX_BarberTime_TimeId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberTimes_BarberId",
                table: "BarberTime",
                newName: "IX_BarberTime_BarberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberTime",
                table: "BarberTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberTime_Barbers_BarberId",
                table: "BarberTime",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberTime_Times_TimeId",
                table: "BarberTime",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
