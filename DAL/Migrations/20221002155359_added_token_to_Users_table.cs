using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class added_token_to_Users_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Barbershops_BarbershopId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BarbershopId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BarbershopId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserBarbershop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BarbershopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBarbershop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBarbershop_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBarbershop_Barbershops_BarbershopId",
                        column: x => x.BarbershopId,
                        principalTable: "Barbershops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBarbershop_BarbershopId",
                table: "UserBarbershop",
                column: "BarbershopId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBarbershop_UserId",
                table: "UserBarbershop",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBarbershop");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BarbershopId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BarbershopId",
                table: "AspNetUsers",
                column: "BarbershopId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Barbershops_BarbershopId",
                table: "AspNetUsers",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id");
        }
    }
}
