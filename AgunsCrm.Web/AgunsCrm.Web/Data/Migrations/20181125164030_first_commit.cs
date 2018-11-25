using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgunsCrm.Web.Data.Migrations
{
    public partial class first_commit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 20, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Coin",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 3, nullable: false),
                    desc = table.Column<string>(maxLength: 50, nullable: false),
                    Symbol = table.Column<string>(maxLength: 5, nullable: true),
                    decimalPlaces = table.Column<int>(nullable: false),
                    logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coin", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 20, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Unity",
                columns: table => new
                {
                    code = table.Column<string>(maxLength: 5, nullable: false),
                    desc = table.Column<string>(maxLength: 50, nullable: true),
                    round = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unity", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "View_PriceList",
                columns: table => new
                {
                    artigo = table.Column<string>(nullable: false),
                    marca = table.Column<string>(nullable: true),
                    marca_Desc = table.Column<string>(nullable: true),
                    familia = table.Column<string>(nullable: true),
                    familia_Desc = table.Column<string>(nullable: true),
                    subFamilia = table.Column<string>(nullable: true),
                    subFamilia_Desc = table.Column<string>(nullable: true),
                    artigo_Desc = table.Column<string>(nullable: true),
                    preco = table.Column<double>(nullable: false),
                    stock = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_View_PriceList", x => x.artigo);
                });

            migrationBuilder.CreateTable(
                name: "SubFamily",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(maxLength: 20, nullable: true),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    familyCode = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFamily", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubFamily_Family_familyCode",
                        column: x => x.familyCode,
                        principalTable: "Family",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(maxLength: 100, nullable: false),
                    desc = table.Column<string>(maxLength: 100, nullable: true),
                    price = table.Column<double>(nullable: false),
                    familyCode = table.Column<string>(maxLength: 20, nullable: true),
                    subFamilyCode = table.Column<int>(nullable: false),
                    brandCode = table.Column<string>(maxLength: 20, nullable: true),
                    notes = table.Column<string>(nullable: true),
                    stock = table.Column<double>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_brandCode",
                        column: x => x.brandCode,
                        principalTable: "Brand",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Family_familyCode",
                        column: x => x.familyCode,
                        principalTable: "Family",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_SubFamily_subFamilyCode",
                        column: x => x.subFamilyCode,
                        principalTable: "SubFamily",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                columns: table => new
                {
                    product = table.Column<int>(nullable: false),
                    coin = table.Column<string>(maxLength: 3, nullable: false),
                    unity = table.Column<string>(maxLength: 5, nullable: false),
                    pvp1 = table.Column<double>(nullable: false),
                    pvp2 = table.Column<double>(nullable: false),
                    pvp3 = table.Column<double>(nullable: false),
                    pvp4 = table.Column<double>(nullable: false),
                    pvp5 = table.Column<double>(nullable: false),
                    pvp6 = table.Column<double>(nullable: false),
                    pvp1VatInclude = table.Column<bool>(nullable: false),
                    pvp2VatInclude = table.Column<bool>(nullable: false),
                    pvp3VatInclude = table.Column<bool>(nullable: false),
                    pvp4VatInclude = table.Column<bool>(nullable: false),
                    pvp5VatInclude = table.Column<bool>(nullable: false),
                    pvp6VatInclude = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrice", x => new { x.product, x.coin, x.unity });
                    table.ForeignKey(
                        name: "FK_ProductPrice_Coin_coin",
                        column: x => x.coin,
                        principalTable: "Coin",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPrice_Product_product",
                        column: x => x.product,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPrice_Unity_unity",
                        column: x => x.unity,
                        principalTable: "Unity",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coin",
                columns: new[] { "code", "Symbol", "decimalPlaces", "desc", "logo" },
                values: new object[,]
                {
                    { "MZN", "MT", 2, "Metical", null },
                    { "USD", "$", 0, "Dollar", null },
                    { "ZAR", "Rand", 0, "Rand's", null },
                    { "EUR", "EUR", 0, "Euro", null }
                });

            migrationBuilder.InsertData(
                table: "Unity",
                columns: new[] { "code", "desc", "round" },
                values: new object[] { "UN", "Unidades", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Product_brandCode",
                table: "Product",
                column: "brandCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_familyCode",
                table: "Product",
                column: "familyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_subFamilyCode",
                table: "Product",
                column: "subFamilyCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_coin",
                table: "ProductPrice",
                column: "coin");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_unity",
                table: "ProductPrice",
                column: "unity");

            migrationBuilder.CreateIndex(
                name: "IX_SubFamily_familyCode",
                table: "SubFamily",
                column: "familyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPrice");

            migrationBuilder.DropTable(
                name: "View_PriceList");

            migrationBuilder.DropTable(
                name: "Coin");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Unity");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "SubFamily");

            migrationBuilder.DropTable(
                name: "Family");
        }
    }
}
