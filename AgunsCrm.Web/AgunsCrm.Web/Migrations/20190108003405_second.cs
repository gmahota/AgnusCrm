using Microsoft.EntityFrameworkCore.Migrations;

namespace AgnusCrm.Web.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Contact",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_userId",
                table: "Contact",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_AspNetUsers_userId",
                table: "Contact",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_AspNetUsers_userId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_userId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Contact",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
