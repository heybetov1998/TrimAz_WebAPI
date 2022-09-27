using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class changed_some_tables_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barber_Barbershops_BarbershopId",
                table: "Barber");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberImages_Barber_BarberId",
                table: "BarberImages");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberServices_Barber_BarberId",
                table: "BarberServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Barber_BarberId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Seller_SellerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerImage_Images_ImageId",
                table: "SellerImage");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerImage_Seller_SellerId",
                table: "SellerImage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBarbers_Barber_BarberId",
                table: "UserBarbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Barber_BarberId",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Video",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellerImage",
                table: "SellerImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barber",
                table: "Barber");

            migrationBuilder.RenameTable(
                name: "Video",
                newName: "Videos");

            migrationBuilder.RenameTable(
                name: "SellerImage",
                newName: "SellerImages");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameTable(
                name: "Barber",
                newName: "Barbers");

            migrationBuilder.RenameIndex(
                name: "IX_Video_BarberId",
                table: "Videos",
                newName: "IX_Videos_BarberId");

            migrationBuilder.RenameIndex(
                name: "IX_SellerImage_SellerId",
                table: "SellerImages",
                newName: "IX_SellerImages_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_SellerImage_ImageId",
                table: "SellerImages",
                newName: "IX_SellerImages_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Barber_BarbershopId",
                table: "Barbers",
                newName: "IX_Barbers_BarbershopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellerImages",
                table: "SellerImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barbers",
                table: "Barbers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberImages_Barbers_BarberId",
                table: "BarberImages",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Barbers_Barbershops_BarbershopId",
                table: "Barbers",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberServices_Barbers_BarberId",
                table: "BarberServices",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Barbers_BarberId",
                table: "Blogs",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerImages_Images_ImageId",
                table: "SellerImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerImages_Sellers_SellerId",
                table: "SellerImages",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBarbers_Barbers_BarberId",
                table: "UserBarbers",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Barbers_BarberId",
                table: "Videos",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberImages_Barbers_BarberId",
                table: "BarberImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Barbers_Barbershops_BarbershopId",
                table: "Barbers");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberServices_Barbers_BarberId",
                table: "BarberServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Barbers_BarberId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerImages_Images_ImageId",
                table: "SellerImages");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerImages_Sellers_SellerId",
                table: "SellerImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBarbers_Barbers_BarberId",
                table: "UserBarbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Barbers_BarberId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellerImages",
                table: "SellerImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Barbers",
                table: "Barbers");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "Video");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "SellerImages",
                newName: "SellerImage");

            migrationBuilder.RenameTable(
                name: "Barbers",
                newName: "Barber");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_BarberId",
                table: "Video",
                newName: "IX_Video_BarberId");

            migrationBuilder.RenameIndex(
                name: "IX_SellerImages_SellerId",
                table: "SellerImage",
                newName: "IX_SellerImage_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_SellerImages_ImageId",
                table: "SellerImage",
                newName: "IX_SellerImage_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Barbers_BarbershopId",
                table: "Barber",
                newName: "IX_Barber_BarbershopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video",
                table: "Video",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellerImage",
                table: "SellerImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Barber",
                table: "Barber",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Barber_Barbershops_BarbershopId",
                table: "Barber",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Barber_BarberId",
                table: "Blogs",
                column: "BarberId",
                principalTable: "Barber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Seller_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerImage_Images_ImageId",
                table: "SellerImage",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerImage_Seller_SellerId",
                table: "SellerImage",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBarbers_Barber_BarberId",
                table: "UserBarbers",
                column: "BarberId",
                principalTable: "Barber",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Barber_BarberId",
                table: "Video",
                column: "BarberId",
                principalTable: "Barber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
