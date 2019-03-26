using Microsoft.EntityFrameworkCore.Migrations;

namespace AgnusCrm.Migrations
{
    public partial class addproductproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_Brandcode",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Family_Familycode",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Familycode",
                table: "Product",
                newName: "familyCode");

            migrationBuilder.RenameColumn(
                name: "Brandcode",
                table: "Product",
                newName: "brandCode");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Familycode",
                table: "Product",
                newName: "IX_Product_familyCode");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Brandcode",
                table: "Product",
                newName: "IX_Product_brandCode");

            migrationBuilder.AddColumn<int>(
                name: "subFamilyCode",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_brandCode",
                table: "Product",
                column: "brandCode",
                principalTable: "Brand",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Family_familyCode",
                table: "Product",
                column: "familyCode",
                principalTable: "Family",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_brandCode",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Family_familyCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "subFamilyCode",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "familyCode",
                table: "Product",
                newName: "Familycode");

            migrationBuilder.RenameColumn(
                name: "brandCode",
                table: "Product",
                newName: "Brandcode");

            migrationBuilder.RenameIndex(
                name: "IX_Product_familyCode",
                table: "Product",
                newName: "IX_Product_Familycode");

            migrationBuilder.RenameIndex(
                name: "IX_Product_brandCode",
                table: "Product",
                newName: "IX_Product_Brandcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_Brandcode",
                table: "Product",
                column: "Brandcode",
                principalTable: "Brand",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Family_Familycode",
                table: "Product",
                column: "Familycode",
                principalTable: "Family",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
