using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class IsAvatar_field_added_to_BarberImages_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberImages_Barber_BarberId",
                table: "BarberImages");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberServices_Barber_BarberId",
                table: "BarberServices");

            migrationBuilder.DropColumn(
                name: "Alt",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsAvatar",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "ServiceDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BarberId",
                table: "BarberServices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BarberId",
                table: "BarberImages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvatar",
                table: "BarberImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberImages_Barber_BarberId",
                table: "BarberImages",
                column: "BarberId",
                principalTable: "Barber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberServices_Barber_BarberId",
                table: "BarberServices",
                column: "BarberId",
                principalTable: "Barber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberImages_Barber_BarberId",
                table: "BarberImages");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberServices_Barber_BarberId",
                table: "BarberServices");

            migrationBuilder.DropColumn(
                name: "IsAvatar",
                table: "BarberImages");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "ServiceDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Alt",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvatar",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "BarberId",
                table: "BarberServices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BarberId",
                table: "BarberImages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberImages_Barber_BarberId",
                table: "BarberImages",
                column: "BarberId",
                principalTable: "Barber",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberServices_Barber_BarberId",
                table: "BarberServices",
                column: "BarberId",
                principalTable: "Barber",
                principalColumn: "Id");
        }
    }
}
