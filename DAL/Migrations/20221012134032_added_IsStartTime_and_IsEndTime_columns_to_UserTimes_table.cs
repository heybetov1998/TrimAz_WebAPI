using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class added_IsStartTime_and_IsEndTime_columns_to_UserTimes_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarberId",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "IsWorkHour",
                table: "UserTimes",
                newName: "IsStartTime");

            migrationBuilder.RenameColumn(
                name: "IsReserved",
                table: "UserTimes",
                newName: "IsEndTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsStartTime",
                table: "UserTimes",
                newName: "IsWorkHour");

            migrationBuilder.RenameColumn(
                name: "IsEndTime",
                table: "UserTimes",
                newName: "IsReserved");

            migrationBuilder.AddColumn<string>(
                name: "BarberId",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
