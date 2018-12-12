using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgnusCrm.Web.Migrations
{
    public partial class update_Contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(maxLength: 20, nullable: true),
                    code = table.Column<string>(maxLength: 20, nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    locality = table.Column<string>(maxLength: 20, nullable: true),
                    contributing_Number = table.Column<string>(maxLength: 20, nullable: true),
                    country = table.Column<string>(maxLength: 20, nullable: true),
                    telphone = table.Column<string>(maxLength: 30, nullable: true),
                    coin = table.Column<string>(maxLength: 3, nullable: true),
                    coinCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entity_Coin_coinCode",
                        column: x => x.coinCode,
                        principalTable: "Coin",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    entityId = table.Column<int>(nullable: false),
                    pvp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_Customer_Entity_entityId",
                        column: x => x.entityId,
                        principalTable: "Entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    productId = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Item_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_entityId",
                table: "Customer",
                column: "entityId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_coinCode",
                table: "Entity",
                column: "coinCode");

            migrationBuilder.CreateIndex(
                name: "IX_Item_productId",
                table: "Item",
                column: "productId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ProductPrice");

            migrationBuilder.DropTable(
                name: "View_PriceList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Unity");

            migrationBuilder.DropTable(
                name: "Coin");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "SubFamily");

            migrationBuilder.DropTable(
                name: "Family");
        }
    }
}
