﻿// <auto-generated />
using System;
using AgnusCrm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgnusCrm.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190302092914_first_commit")]
    partial class first_commit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgnusCrm.Models.Brand", b =>
                {
                    b.Property<string>("code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("description")
                        .HasMaxLength(50);

                    b.HasKey("code");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("AgnusCrm.Models.Coin", b =>
                {
                    b.Property<string>("code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3);

                    b.Property<string>("Symbol")
                        .HasMaxLength(5);

                    b.Property<int>("decimalPlaces");

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("logo");

                    b.HasKey("code");

                    b.ToTable("Coin");

                    b.HasData(
                        new
                        {
                            code = "MZN",
                            Symbol = "MT",
                            decimalPlaces = 2,
                            desc = "Metical"
                        },
                        new
                        {
                            code = "USD",
                            Symbol = "$",
                            decimalPlaces = 0,
                            desc = "Dollar"
                        },
                        new
                        {
                            code = "ZAR",
                            Symbol = "Rand",
                            decimalPlaces = 0,
                            desc = "Rand's"
                        },
                        new
                        {
                            code = "EUR",
                            Symbol = "EUR",
                            decimalPlaces = 0,
                            desc = "Euro"
                        });
                });

            modelBuilder.Entity("AgnusCrm.Models.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.Property<string>("cellPhone")
                        .HasMaxLength(20);

                    b.Property<string>("code")
                        .HasMaxLength(20);

                    b.Property<string>("email");

                    b.Property<string>("emailAlt")
                        .HasMaxLength(50);

                    b.Property<string>("firstName")
                        .HasMaxLength(50);

                    b.Property<string>("fullName")
                        .HasMaxLength(100);

                    b.Property<string>("lastName")
                        .HasMaxLength(50);

                    b.Property<string>("middleName")
                        .HasMaxLength(50);

                    b.Property<string>("telephone")
                        .HasMaxLength(20);

                    b.Property<string>("title")
                        .HasMaxLength(10);

                    b.Property<string>("type")
                        .HasMaxLength(20);

                    b.Property<string>("userId");

                    b.HasKey("id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("AgnusCrm.Models.Contact_Entity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("contactId");

                    b.Property<int>("entityId");

                    b.Property<string>("name")
                        .HasMaxLength(20);

                    b.Property<string>("type")
                        .HasMaxLength(20);

                    b.Property<string>("value")
                        .HasMaxLength(20);

                    b.HasKey("id");

                    b.HasIndex("contactId");

                    b.HasIndex("entityId");

                    b.ToTable("Contact_Entity");
                });

            modelBuilder.Entity("AgnusCrm.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("entityId");

                    b.Property<int>("pvp");

                    b.HasKey("id");

                    b.HasIndex("entityId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("AgnusCrm.Models.Entity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasMaxLength(100);

                    b.Property<string>("code")
                        .HasMaxLength(20);

                    b.Property<string>("coin")
                        .HasMaxLength(3);

                    b.Property<string>("contributing_Number")
                        .HasMaxLength(20);

                    b.Property<string>("country")
                        .HasMaxLength(20);

                    b.Property<string>("locality")
                        .HasMaxLength(20);

                    b.Property<string>("name")
                        .HasMaxLength(50);

                    b.Property<string>("telphone")
                        .HasMaxLength(30);

                    b.Property<string>("type")
                        .HasMaxLength(20);

                    b.HasKey("id");

                    b.HasIndex("coin");

                    b.ToTable("Entity");
                });

            modelBuilder.Entity("AgnusCrm.Models.Family", b =>
                {
                    b.Property<string>("code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("description")
                        .HasMaxLength(50);

                    b.HasKey("code");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("AgnusCrm.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("price");

                    b.Property<int>("productId");

                    b.Property<int>("quantity");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("AgnusCrm.Models.PriceList.ViewPriceList", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("brand_desc");

                    b.Property<string>("desc");

                    b.Property<bool>("encomenda");

                    b.Property<string>("family_desc");

                    b.Property<double>("price");

                    b.Property<double>("stock");

                    b.Property<string>("subFamily_desc");

                    b.HasKey("id");

                    b.ToTable("ViewPriceList");
                });

            modelBuilder.Entity("AgnusCrm.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("brandCode")
                        .HasMaxLength(20);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("desc")
                        .HasMaxLength(100);

                    b.Property<string>("familyCode")
                        .HasMaxLength(20);

                    b.Property<string>("notes");

                    b.Property<double>("price");

                    b.Property<int>("status");

                    b.Property<double>("stock");

                    b.Property<int>("subFamilyCode");

                    b.HasKey("id");

                    b.HasIndex("brandCode");

                    b.HasIndex("familyCode");

                    b.HasIndex("subFamilyCode");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AgnusCrm.Models.ProductPrice", b =>
                {
                    b.Property<int>("product");

                    b.Property<string>("coin")
                        .HasMaxLength(3);

                    b.Property<string>("unity")
                        .HasMaxLength(5);

                    b.Property<double>("pvp1");

                    b.Property<bool>("pvp1VatInclude");

                    b.Property<double>("pvp2");

                    b.Property<bool>("pvp2VatInclude");

                    b.Property<double>("pvp3");

                    b.Property<bool>("pvp3VatInclude");

                    b.Property<double>("pvp4");

                    b.Property<bool>("pvp4VatInclude");

                    b.Property<double>("pvp5");

                    b.Property<bool>("pvp5VatInclude");

                    b.Property<double>("pvp6");

                    b.Property<bool>("pvp6VatInclude");

                    b.HasKey("product", "coin", "unity");

                    b.HasIndex("coin");

                    b.HasIndex("unity");

                    b.ToTable("ProductPrice");
                });

            modelBuilder.Entity("AgnusCrm.Models.SubFamily", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasMaxLength(20);

                    b.Property<string>("description")
                        .HasMaxLength(50);

                    b.Property<string>("familyCode")
                        .HasMaxLength(20);

                    b.HasKey("id");

                    b.HasIndex("familyCode");

                    b.ToTable("SubFamily");
                });

            modelBuilder.Entity("AgnusCrm.Models.Unity", b =>
                {
                    b.Property<string>("code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5);

                    b.Property<string>("desc")
                        .HasMaxLength(50);

                    b.Property<int>("round");

                    b.HasKey("code");

                    b.ToTable("Unity");

                    b.HasData(
                        new
                        {
                            code = "UN",
                            desc = "Unidades",
                            round = 2
                        });
                });

            modelBuilder.Entity("AgnusCrm.Models.View_PriceList", b =>
                {
                    b.Property<string>("artigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("artigo_Desc");

                    b.Property<string>("familia");

                    b.Property<string>("familia_Desc");

                    b.Property<string>("marca");

                    b.Property<string>("marca_Desc");

                    b.Property<double>("preco");

                    b.Property<double>("stock");

                    b.Property<string>("subFamilia");

                    b.Property<string>("subFamilia_Desc");

                    b.HasKey("artigo");

                    b.ToTable("View_PriceList");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AgnusCrm.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("ApplicationUserRole");

                    b.Property<bool>("isSuperAdmin");

                    b.Property<string>("profilePictureUrl");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("AgnusCrm.Models.Contact_Entity", b =>
                {
                    b.HasOne("AgnusCrm.Models.Contact", "contact")
                        .WithMany("contact_Itens")
                        .HasForeignKey("contactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgnusCrm.Models.Entity", "entity")
                        .WithMany("listContact")
                        .HasForeignKey("entityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgnusCrm.Models.Customer", b =>
                {
                    b.HasOne("AgnusCrm.Models.Entity", "entity")
                        .WithMany()
                        .HasForeignKey("entityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgnusCrm.Models.Entity", b =>
                {
                    b.HasOne("AgnusCrm.Models.Coin", "Coin")
                        .WithMany()
                        .HasForeignKey("coin");
                });

            modelBuilder.Entity("AgnusCrm.Models.Item", b =>
                {
                    b.HasOne("AgnusCrm.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgnusCrm.Models.Product", b =>
                {
                    b.HasOne("AgnusCrm.Models.Brand", "Brand")
                        .WithMany("listProducts")
                        .HasForeignKey("brandCode");

                    b.HasOne("AgnusCrm.Models.Family", "Family")
                        .WithMany("listProducts")
                        .HasForeignKey("familyCode");

                    b.HasOne("AgnusCrm.Models.SubFamily", "SubFamily")
                        .WithMany()
                        .HasForeignKey("subFamilyCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgnusCrm.Models.ProductPrice", b =>
                {
                    b.HasOne("AgnusCrm.Models.Coin", "Coin")
                        .WithMany()
                        .HasForeignKey("coin")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgnusCrm.Models.Product", "Product")
                        .WithMany("ProductPrice")
                        .HasForeignKey("product")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgnusCrm.Models.Unity", "Unity")
                        .WithMany()
                        .HasForeignKey("unity")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgnusCrm.Models.SubFamily", b =>
                {
                    b.HasOne("AgnusCrm.Models.Family", "family")
                        .WithMany("listSubFamilys")
                        .HasForeignKey("familyCode");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
