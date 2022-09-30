using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Times_table_Id_field_custom_generation_disablet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberTimes_Times_TimeId",
                table: "BarberTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Times",
                table: "Times");

            migrationBuilder.DropIndex(
                name: "IX_BarberTimes_TimeId",
                table: "BarberTimes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Times");

            migrationBuilder.AlterColumn<string>(
                name: "Range",
                table: "Times",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TimeRange",
                table: "BarberTimes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Times",
                table: "Times",
                column: "Range");

            migrationBuilder.CreateIndex(
                name: "IX_BarberTimes_TimeRange",
                table: "BarberTimes",
                column: "TimeRange");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberTimes_Times_TimeRange",
                table: "BarberTimes",
                column: "TimeRange",
                principalTable: "Times",
                principalColumn: "Range",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberTimes_Times_TimeRange",
                table: "BarberTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Times",
                table: "Times");

            migrationBuilder.DropIndex(
                name: "IX_BarberTimes_TimeRange",
                table: "BarberTimes");

            migrationBuilder.DropColumn(
                name: "TimeRange",
                table: "BarberTimes");

            migrationBuilder.AlterColumn<string>(
                name: "Range",
                table: "Times",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Times",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Times",
                table: "Times",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BarberTimes_TimeId",
                table: "BarberTimes",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberTimes_Times_TimeId",
                table: "BarberTimes",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
