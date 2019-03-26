using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgnusCrm.Migrations
{
    public partial class firstcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountExecutive",
                columns: table => new
                {
                    accountExecutiveId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    accountExecutiveName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true),
                    systemUserId = table.Column<string>(maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountExecutive", x => x.accountExecutiveId);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    activityId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    activityName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    colorHex = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.activityId);
                });

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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    AccountExecutiveRole = table.Column<bool>(nullable: true),
                    ActivityRole = table.Column<bool>(nullable: true),
                    ChannelRole = table.Column<bool>(nullable: true),
                    DashboardRole = table.Column<bool>(nullable: true),
                    LeadRole = table.Column<bool>(nullable: true),
                    LeadLineRole = table.Column<bool>(nullable: true),
                    OpportunityRole = table.Column<bool>(nullable: true),
                    OpportunityLineRole = table.Column<bool>(nullable: true),
                    RatingRole = table.Column<bool>(nullable: true),
                    StageRole = table.Column<bool>(nullable: true),
                    BranchRole = table.Column<bool>(nullable: true),
                    CustomerRole = table.Column<bool>(nullable: true),
                    CustomerLineRole = table.Column<bool>(nullable: true),
                    ProductRole = table.Column<bool>(nullable: true),
                    PurchaseOrderRole = table.Column<bool>(nullable: true),
                    PurchaseOrderLineRole = table.Column<bool>(nullable: true),
                    ReceivingRole = table.Column<bool>(nullable: true),
                    ReceivingLineRole = table.Column<bool>(nullable: true),
                    SalesOrderRole = table.Column<bool>(nullable: true),
                    SalesOrderLineRole = table.Column<bool>(nullable: true),
                    ShipmentRole = table.Column<bool>(nullable: true),
                    ShipmentLineRole = table.Column<bool>(nullable: true),
                    StockRole = table.Column<bool>(nullable: true),
                    TransferInRole = table.Column<bool>(nullable: true),
                    TransferInLineRole = table.Column<bool>(nullable: true),
                    TransferOrderRole = table.Column<bool>(nullable: true),
                    TransferOrderLineRole = table.Column<bool>(nullable: true),
                    TransferOutRole = table.Column<bool>(nullable: true),
                    TransferOutLineRole = table.Column<bool>(nullable: true),
                    VendorRole = table.Column<bool>(nullable: true),
                    VendorLineRole = table.Column<bool>(nullable: true),
                    WarehouseRole = table.Column<bool>(nullable: true),
                    profilePictureUrl = table.Column<string>(nullable: true),
                    isSuperAdmin = table.Column<bool>(nullable: true),
                    ApplicationUserRole = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    branchId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    branchName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    isDefaultBranch = table.Column<bool>(nullable: false),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.branchId);
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
                name: "Channel",
                columns: table => new
                {
                    channelId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    channelName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    colorHex = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.channelId);
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
                name: "Contact",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(maxLength: 20, nullable: true),
                    fullName = table.Column<string>(maxLength: 100, nullable: true),
                    firstName = table.Column<string>(maxLength: 50, nullable: true),
                    middleName = table.Column<string>(maxLength: 50, nullable: true),
                    lastName = table.Column<string>(maxLength: 50, nullable: true),
                    title = table.Column<string>(maxLength: 10, nullable: true),
                    email = table.Column<string>(nullable: true),
                    emailAlt = table.Column<string>(maxLength: 50, nullable: true),
                    type = table.Column<string>(maxLength: 20, nullable: true),
                    cellPhone = table.Column<string>(maxLength: 20, nullable: true),
                    telephone = table.Column<string>(maxLength: 20, nullable: true),
                    userId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    customerName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    size = table.Column<int>(nullable: false),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true),
                    pvp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
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
                name: "Rating",
                columns: table => new
                {
                    ratingId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    ratingName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    colorHex = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ratingId);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    stageId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    stageName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    colorHex = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.stageId);
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
                name: "Vendor",
                columns: table => new
                {
                    vendorId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    vendorName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    size = table.Column<int>(nullable: false),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.vendorId);
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
                name: "ViewPriceList",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    brand_desc = table.Column<string>(nullable: true),
                    family_desc = table.Column<string>(nullable: true),
                    subFamily_desc = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    stock = table.Column<double>(nullable: false),
                    encomenda = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewPriceList", x => x.id);
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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
                name: "Warehouse",
                columns: table => new
                {
                    warehouseId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    warehouseName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.warehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouse_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    leadId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    leadName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true),
                    isQualified = table.Column<bool>(nullable: false),
                    isConverted = table.Column<bool>(nullable: false),
                    channelId = table.Column<string>(maxLength: 38, nullable: true),
                    customerId = table.Column<string>(maxLength: 38, nullable: true),
                    accountExecutiveId = table.Column<string>(maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.leadId);
                    table.ForeignKey(
                        name: "FK_Lead_AccountExecutive_accountExecutiveId",
                        column: x => x.accountExecutiveId,
                        principalTable: "AccountExecutive",
                        principalColumn: "accountExecutiveId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lead_Channel_channelId",
                        column: x => x.channelId,
                        principalTable: "Channel",
                        principalColumn: "channelId",
                        onDelete: ReferentialAction.Restrict);
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
                    coin = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entity_Coin_coin",
                        column: x => x.coin,
                        principalTable: "Coin",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLine",
                columns: table => new
                {
                    customerLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    jobTitle = table.Column<string>(maxLength: 20, nullable: false),
                    customerId = table.Column<string>(maxLength: 38, nullable: true),
                    firstName = table.Column<string>(maxLength: 20, nullable: false),
                    lastName = table.Column<string>(maxLength: 20, nullable: false),
                    middleName = table.Column<string>(maxLength: 20, nullable: true),
                    nickName = table.Column<string>(maxLength: 20, nullable: true),
                    gender = table.Column<int>(nullable: false),
                    salutation = table.Column<int>(nullable: false),
                    mobilePhone = table.Column<string>(maxLength: 20, nullable: true),
                    officePhone = table.Column<string>(maxLength: 20, nullable: true),
                    fax = table.Column<string>(maxLength: 20, nullable: true),
                    personalEmail = table.Column<string>(maxLength: 50, nullable: true),
                    workEmail = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLine", x => x.customerLineId);
                    table.ForeignKey(
                        name: "FK_CustomerLine_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    salesOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    salesOrderNumber = table.Column<string>(maxLength: 20, nullable: false),
                    top = table.Column<int>(nullable: false),
                    soDate = table.Column<DateTime>(nullable: false),
                    deliveryDate = table.Column<DateTime>(nullable: false),
                    deliveryAddress = table.Column<string>(maxLength: 50, nullable: true),
                    referenceNumberInternal = table.Column<string>(maxLength: 30, nullable: true),
                    referenceNumberExternal = table.Column<string>(maxLength: 30, nullable: true),
                    description = table.Column<string>(maxLength: 100, nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: false),
                    customerId = table.Column<string>(maxLength: 38, nullable: false),
                    picInternal = table.Column<string>(maxLength: 30, nullable: false),
                    picCustomer = table.Column<string>(maxLength: 30, nullable: false),
                    salesOrderStatus = table.Column<int>(nullable: false),
                    totalDiscountAmount = table.Column<decimal>(nullable: false),
                    totalOrderAmount = table.Column<decimal>(nullable: false),
                    salesShipmentNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.salesOrderId);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    productCode = table.Column<string>(maxLength: 50, nullable: false),
                    productName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    barcode = table.Column<string>(maxLength: 50, nullable: true),
                    serialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    productType = table.Column<int>(nullable: false),
                    uom = table.Column<int>(nullable: false),
                    Brandcode = table.Column<string>(nullable: true),
                    Familycode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Product_Brand_Brandcode",
                        column: x => x.Brandcode,
                        principalTable: "Brand",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Family_Familycode",
                        column: x => x.Familycode,
                        principalTable: "Family",
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
                name: "Opportunity",
                columns: table => new
                {
                    opportunityId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    opportunityName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    stageId = table.Column<string>(maxLength: 38, nullable: true),
                    accountExecutiveId = table.Column<string>(maxLength: 38, nullable: true),
                    customerId = table.Column<string>(maxLength: 38, nullable: true),
                    estimatedRevenue = table.Column<decimal>(nullable: false),
                    estimatedClosingDate = table.Column<DateTime>(nullable: false),
                    probability = table.Column<int>(nullable: false),
                    ratingId = table.Column<string>(maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.opportunityId);
                    table.ForeignKey(
                        name: "FK_Opportunity_AccountExecutive_accountExecutiveId",
                        column: x => x.accountExecutiveId,
                        principalTable: "AccountExecutive",
                        principalColumn: "accountExecutiveId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunity_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunity_Rating_ratingId",
                        column: x => x.ratingId,
                        principalTable: "Rating",
                        principalColumn: "ratingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opportunity_Stage_stageId",
                        column: x => x.stageId,
                        principalTable: "Stage",
                        principalColumn: "stageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    purchaseOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    purchaseOrderNumber = table.Column<string>(maxLength: 20, nullable: false),
                    top = table.Column<int>(nullable: false),
                    poDate = table.Column<DateTime>(nullable: false),
                    deliveryDate = table.Column<DateTime>(nullable: false),
                    deliveryAddress = table.Column<string>(maxLength: 50, nullable: true),
                    referenceNumberInternal = table.Column<string>(maxLength: 30, nullable: true),
                    referenceNumberExternal = table.Column<string>(maxLength: 30, nullable: true),
                    description = table.Column<string>(maxLength: 100, nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: false),
                    vendorId = table.Column<string>(maxLength: 38, nullable: false),
                    picInternal = table.Column<string>(maxLength: 30, nullable: false),
                    picVendor = table.Column<string>(maxLength: 30, nullable: false),
                    purchaseOrderStatus = table.Column<int>(nullable: false),
                    totalDiscountAmount = table.Column<decimal>(nullable: false),
                    totalOrderAmount = table.Column<decimal>(nullable: false),
                    purchaseReceiveNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.purchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Vendor_vendorId",
                        column: x => x.vendorId,
                        principalTable: "Vendor",
                        principalColumn: "vendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorLine",
                columns: table => new
                {
                    vendorLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    jobTitle = table.Column<string>(maxLength: 20, nullable: false),
                    vendorId = table.Column<string>(maxLength: 38, nullable: true),
                    firstName = table.Column<string>(maxLength: 20, nullable: false),
                    lastName = table.Column<string>(maxLength: 20, nullable: false),
                    middleName = table.Column<string>(maxLength: 20, nullable: true),
                    nickName = table.Column<string>(maxLength: 20, nullable: true),
                    gender = table.Column<int>(nullable: false),
                    salutation = table.Column<int>(nullable: false),
                    mobilePhone = table.Column<string>(maxLength: 20, nullable: true),
                    officePhone = table.Column<string>(maxLength: 20, nullable: true),
                    fax = table.Column<string>(maxLength: 20, nullable: true),
                    personalEmail = table.Column<string>(maxLength: 50, nullable: true),
                    workEmail = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorLine", x => x.vendorLineId);
                    table.ForeignKey(
                        name: "FK_VendorLine_Vendor_vendorId",
                        column: x => x.vendorId,
                        principalTable: "Vendor",
                        principalColumn: "vendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferOrder",
                columns: table => new
                {
                    transferOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    transferOrderNumber = table.Column<string>(maxLength: 20, nullable: false),
                    transferOrderDate = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    picName = table.Column<string>(maxLength: 50, nullable: false),
                    branchIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    branchFrombranchId = table.Column<string>(nullable: true),
                    warehouseIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseFromwarehouseId = table.Column<string>(nullable: true),
                    branchIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    branchTobranchId = table.Column<string>(nullable: true),
                    warehouseIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseTowarehouseId = table.Column<string>(nullable: true),
                    transferOrderStatus = table.Column<int>(nullable: false),
                    isIssued = table.Column<bool>(nullable: false),
                    isReceived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOrder", x => x.transferOrderId);
                    table.ForeignKey(
                        name: "FK_TransferOrder_Branch_branchFrombranchId",
                        column: x => x.branchFrombranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOrder_Branch_branchTobranchId",
                        column: x => x.branchTobranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOrder_Warehouse_warehouseFromwarehouseId",
                        column: x => x.warehouseFromwarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOrder_Warehouse_warehouseTowarehouseId",
                        column: x => x.warehouseTowarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadLine",
                columns: table => new
                {
                    leadLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    leadId = table.Column<string>(maxLength: 38, nullable: true),
                    activityId = table.Column<string>(maxLength: 38, nullable: true),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadLine", x => x.leadLineId);
                    table.ForeignKey(
                        name: "FK_LeadLine_Activity_activityId",
                        column: x => x.activityId,
                        principalTable: "Activity",
                        principalColumn: "activityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeadLine_Lead_leadId",
                        column: x => x.leadId,
                        principalTable: "Lead",
                        principalColumn: "leadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact_Entity",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contactId = table.Column<int>(nullable: false),
                    entityId = table.Column<int>(nullable: false),
                    type = table.Column<string>(maxLength: 20, nullable: true),
                    name = table.Column<string>(maxLength: 20, nullable: true),
                    value = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_Entity", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contact_Entity_Contact_contactId",
                        column: x => x.contactId,
                        principalTable: "Contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_Entity_Entity_entityId",
                        column: x => x.entityId,
                        principalTable: "Entity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    shipmentId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    salesOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    shipmentNumber = table.Column<string>(maxLength: 20, nullable: false),
                    shipmentDate = table.Column<DateTime>(nullable: false),
                    customerId = table.Column<string>(maxLength: 38, nullable: true),
                    customerPO = table.Column<string>(maxLength: 50, nullable: true),
                    invoice = table.Column<string>(maxLength: 50, nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseId = table.Column<string>(maxLength: 38, nullable: false),
                    expeditionType = table.Column<int>(nullable: false),
                    expeditionMode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.shipmentId);
                    table.ForeignKey(
                        name: "FK_Shipment_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipment_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipment_SalesOrder_salesOrderId",
                        column: x => x.salesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "salesOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipment_Warehouse_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    productCode = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    productId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Item_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                columns: table => new
                {
                    productCode = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_ProductPrice", x => new { x.productCode, x.coin, x.unity });
                    table.ForeignKey(
                        name: "FK_ProductPrice_Coin_coin",
                        column: x => x.coin,
                        principalTable: "Coin",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPrice_Product_productCode",
                        column: x => x.productCode,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPrice_Unity_unity",
                        column: x => x.unity,
                        principalTable: "Unity",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderLine",
                columns: table => new
                {
                    salesOrderLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    salesOrderId = table.Column<string>(maxLength: 38, nullable: true),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    discountAmount = table.Column<decimal>(nullable: false),
                    totalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderLine", x => x.salesOrderLineId);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_SalesOrder_salesOrderId",
                        column: x => x.salesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "salesOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityLine",
                columns: table => new
                {
                    opportunityLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    opportunityId = table.Column<string>(maxLength: 38, nullable: true),
                    activityId = table.Column<string>(maxLength: 38, nullable: true),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityLine", x => x.opportunityLineId);
                    table.ForeignKey(
                        name: "FK_OpportunityLine_Activity_activityId",
                        column: x => x.activityId,
                        principalTable: "Activity",
                        principalColumn: "activityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpportunityLine_Opportunity_opportunityId",
                        column: x => x.opportunityId,
                        principalTable: "Opportunity",
                        principalColumn: "opportunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLine",
                columns: table => new
                {
                    purchaseOrderLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    purchaseOrderId = table.Column<string>(maxLength: 38, nullable: true),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    discountAmount = table.Column<decimal>(nullable: false),
                    totalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLine", x => x.purchaseOrderLineId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLine_PurchaseOrder_purchaseOrderId",
                        column: x => x.purchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "purchaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receiving",
                columns: table => new
                {
                    receivingId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    purchaseOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    receivingNumber = table.Column<string>(maxLength: 20, nullable: false),
                    receivingDate = table.Column<DateTime>(nullable: false),
                    vendorId = table.Column<string>(maxLength: 38, nullable: true),
                    vendorDO = table.Column<string>(maxLength: 50, nullable: false),
                    vendorInvoice = table.Column<string>(maxLength: 50, nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseId = table.Column<string>(maxLength: 38, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receiving", x => x.receivingId);
                    table.ForeignKey(
                        name: "FK_Receiving_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiving_PurchaseOrder_purchaseOrderId",
                        column: x => x.purchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "purchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receiving_Vendor_vendorId",
                        column: x => x.vendorId,
                        principalTable: "Vendor",
                        principalColumn: "vendorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiving_Warehouse_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferIn",
                columns: table => new
                {
                    transferInId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    transferOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    transferInNumber = table.Column<string>(maxLength: 20, nullable: false),
                    transferInDate = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    branchIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    branchFrombranchId = table.Column<string>(nullable: true),
                    warehouseIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseFromwarehouseId = table.Column<string>(nullable: true),
                    branchIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    branchTobranchId = table.Column<string>(nullable: true),
                    warehouseIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseTowarehouseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferIn", x => x.transferInId);
                    table.ForeignKey(
                        name: "FK_TransferIn_Branch_branchFrombranchId",
                        column: x => x.branchFrombranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferIn_Branch_branchTobranchId",
                        column: x => x.branchTobranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferIn_TransferOrder_transferOrderId",
                        column: x => x.transferOrderId,
                        principalTable: "TransferOrder",
                        principalColumn: "transferOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferIn_Warehouse_warehouseFromwarehouseId",
                        column: x => x.warehouseFromwarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferIn_Warehouse_warehouseTowarehouseId",
                        column: x => x.warehouseTowarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferOrderLine",
                columns: table => new
                {
                    transferOrderLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    transferOrderId = table.Column<string>(maxLength: 38, nullable: true),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOrderLine", x => x.transferOrderLineId);
                    table.ForeignKey(
                        name: "FK_TransferOrderLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOrderLine_TransferOrder_transferOrderId",
                        column: x => x.transferOrderId,
                        principalTable: "TransferOrder",
                        principalColumn: "transferOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferOut",
                columns: table => new
                {
                    transferOutId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    transferOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    transferOutNumber = table.Column<string>(maxLength: 20, nullable: false),
                    transferOutDate = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    branchIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    branchFrombranchId = table.Column<string>(nullable: true),
                    warehouseIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseFromwarehouseId = table.Column<string>(nullable: true),
                    branchIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    branchTobranchId = table.Column<string>(nullable: true),
                    warehouseIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseTowarehouseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOut", x => x.transferOutId);
                    table.ForeignKey(
                        name: "FK_TransferOut_Branch_branchFrombranchId",
                        column: x => x.branchFrombranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOut_Branch_branchTobranchId",
                        column: x => x.branchTobranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOut_TransferOrder_transferOrderId",
                        column: x => x.transferOrderId,
                        principalTable: "TransferOrder",
                        principalColumn: "transferOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferOut_Warehouse_warehouseFromwarehouseId",
                        column: x => x.warehouseFromwarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOut_Warehouse_warehouseTowarehouseId",
                        column: x => x.warehouseTowarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentLine",
                columns: table => new
                {
                    shipmentLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    shipmentId = table.Column<string>(maxLength: 38, nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseId = table.Column<string>(maxLength: 38, nullable: true),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    qtyShipment = table.Column<float>(nullable: false),
                    qtyInventory = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentLine", x => x.shipmentLineId);
                    table.ForeignKey(
                        name: "FK_ShipmentLine_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentLine_Shipment_shipmentId",
                        column: x => x.shipmentId,
                        principalTable: "Shipment",
                        principalColumn: "shipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentLine_Warehouse_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingLine",
                columns: table => new
                {
                    receivingLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    receivingId = table.Column<string>(maxLength: 38, nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseId = table.Column<string>(maxLength: 38, nullable: true),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    qtyReceive = table.Column<float>(nullable: false),
                    qtyInventory = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingLine", x => x.receivingLineId);
                    table.ForeignKey(
                        name: "FK_ReceivingLine_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingLine_Receiving_receivingId",
                        column: x => x.receivingId,
                        principalTable: "Receiving",
                        principalColumn: "receivingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingLine_Warehouse_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferInLine",
                columns: table => new
                {
                    transferInLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    transferInId = table.Column<string>(maxLength: 38, nullable: true),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    qtyInventory = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferInLine", x => x.transferInLineId);
                    table.ForeignKey(
                        name: "FK_TransferInLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferInLine_TransferIn_transferInId",
                        column: x => x.transferInId,
                        principalTable: "TransferIn",
                        principalColumn: "transferInId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferOutLine",
                columns: table => new
                {
                    transferOutLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    transferOutId = table.Column<string>(maxLength: 38, nullable: true),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    qtyInventory = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOutLine", x => x.transferOutLineId);
                    table.ForeignKey(
                        name: "FK_TransferOutLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOutLine_TransferOut_transferOutId",
                        column: x => x.transferOutId,
                        principalTable: "TransferOut",
                        principalColumn: "transferOutId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Contact_Entity_contactId",
                table: "Contact_Entity",
                column: "contactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Entity_entityId",
                table: "Contact_Entity",
                column: "entityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLine_customerId",
                table: "CustomerLine",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_coin",
                table: "Entity",
                column: "coin");

            migrationBuilder.CreateIndex(
                name: "IX_Item_productId",
                table: "Item",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_accountExecutiveId",
                table: "Lead",
                column: "accountExecutiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_channelId",
                table: "Lead",
                column: "channelId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadLine_activityId",
                table: "LeadLine",
                column: "activityId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadLine_leadId",
                table: "LeadLine",
                column: "leadId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_accountExecutiveId",
                table: "Opportunity",
                column: "accountExecutiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_customerId",
                table: "Opportunity",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_ratingId",
                table: "Opportunity",
                column: "ratingId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_stageId",
                table: "Opportunity",
                column: "stageId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityLine_activityId",
                table: "OpportunityLine",
                column: "activityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityLine_opportunityId",
                table: "OpportunityLine",
                column: "opportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Brandcode",
                table: "Product",
                column: "Brandcode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Familycode",
                table: "Product",
                column: "Familycode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_coin",
                table: "ProductPrice",
                column: "coin");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_unity",
                table: "ProductPrice",
                column: "unity");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_branchId",
                table: "PurchaseOrder",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_vendorId",
                table: "PurchaseOrder",
                column: "vendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLine_productId",
                table: "PurchaseOrderLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLine_purchaseOrderId",
                table: "PurchaseOrderLine",
                column: "purchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_branchId",
                table: "Receiving",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_purchaseOrderId",
                table: "Receiving",
                column: "purchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_vendorId",
                table: "Receiving",
                column: "vendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_warehouseId",
                table: "Receiving",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLine_branchId",
                table: "ReceivingLine",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLine_productId",
                table: "ReceivingLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLine_receivingId",
                table: "ReceivingLine",
                column: "receivingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLine_warehouseId",
                table: "ReceivingLine",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_branchId",
                table: "SalesOrder",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_customerId",
                table: "SalesOrder",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_productId",
                table: "SalesOrderLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_salesOrderId",
                table: "SalesOrderLine",
                column: "salesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_branchId",
                table: "Shipment",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_customerId",
                table: "Shipment",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_salesOrderId",
                table: "Shipment",
                column: "salesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_warehouseId",
                table: "Shipment",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLine_branchId",
                table: "ShipmentLine",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLine_productId",
                table: "ShipmentLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLine_shipmentId",
                table: "ShipmentLine",
                column: "shipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLine_warehouseId",
                table: "ShipmentLine",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SubFamily_familyCode",
                table: "SubFamily",
                column: "familyCode");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_branchFrombranchId",
                table: "TransferIn",
                column: "branchFrombranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_branchTobranchId",
                table: "TransferIn",
                column: "branchTobranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_transferOrderId",
                table: "TransferIn",
                column: "transferOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_warehouseFromwarehouseId",
                table: "TransferIn",
                column: "warehouseFromwarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_warehouseTowarehouseId",
                table: "TransferIn",
                column: "warehouseTowarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferInLine_productId",
                table: "TransferInLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferInLine_transferInId",
                table: "TransferInLine",
                column: "transferInId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_branchFrombranchId",
                table: "TransferOrder",
                column: "branchFrombranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_branchTobranchId",
                table: "TransferOrder",
                column: "branchTobranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_warehouseFromwarehouseId",
                table: "TransferOrder",
                column: "warehouseFromwarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_warehouseTowarehouseId",
                table: "TransferOrder",
                column: "warehouseTowarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrderLine_productId",
                table: "TransferOrderLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrderLine_transferOrderId",
                table: "TransferOrderLine",
                column: "transferOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_branchFrombranchId",
                table: "TransferOut",
                column: "branchFrombranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_branchTobranchId",
                table: "TransferOut",
                column: "branchTobranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_transferOrderId",
                table: "TransferOut",
                column: "transferOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_warehouseFromwarehouseId",
                table: "TransferOut",
                column: "warehouseFromwarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_warehouseTowarehouseId",
                table: "TransferOut",
                column: "warehouseTowarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOutLine_productId",
                table: "TransferOutLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOutLine_transferOutId",
                table: "TransferOutLine",
                column: "transferOutId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorLine_vendorId",
                table: "VendorLine",
                column: "vendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_branchId",
                table: "Warehouse",
                column: "branchId");
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
                name: "Contact_Entity");

            migrationBuilder.DropTable(
                name: "CustomerLine");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "LeadLine");

            migrationBuilder.DropTable(
                name: "OpportunityLine");

            migrationBuilder.DropTable(
                name: "ProductPrice");

            migrationBuilder.DropTable(
                name: "PurchaseOrderLine");

            migrationBuilder.DropTable(
                name: "ReceivingLine");

            migrationBuilder.DropTable(
                name: "SalesOrderLine");

            migrationBuilder.DropTable(
                name: "ShipmentLine");

            migrationBuilder.DropTable(
                name: "SubFamily");

            migrationBuilder.DropTable(
                name: "TransferInLine");

            migrationBuilder.DropTable(
                name: "TransferOrderLine");

            migrationBuilder.DropTable(
                name: "TransferOutLine");

            migrationBuilder.DropTable(
                name: "VendorLine");

            migrationBuilder.DropTable(
                name: "View_PriceList");

            migrationBuilder.DropTable(
                name: "ViewPriceList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Opportunity");

            migrationBuilder.DropTable(
                name: "Unity");

            migrationBuilder.DropTable(
                name: "Receiving");

            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropTable(
                name: "TransferIn");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "TransferOut");

            migrationBuilder.DropTable(
                name: "Coin");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "AccountExecutive");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropTable(
                name: "TransferOrder");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
