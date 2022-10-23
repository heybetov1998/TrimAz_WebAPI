using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class removedFeedbacksFromAppUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_AppUserId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_AppUserId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Feedbacks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Feedbacks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_AppUserId",
                table: "Feedbacks",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_AppUserId",
                table: "Feedbacks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
