using System;
using System.Collections.Generic;
using System.Text;
using AgnusCrm.Models;
using AgnusCrm.Models.PriceList;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgnusCrm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region GeneralSeed
            builder.Entity<ProductPrice>()
                .HasKey(a => new { a.product, a.coin, a.unity });

            builder.Entity<Coin>().HasData(
                new Coin { code = "MZN", desc = "Metical", decimalPlaces = 2, Symbol = "MT" },
                new Coin { code = "USD", desc = "Dollar", decimalPlaces = 0, Symbol = "$" },
                new Coin { code = "ZAR", desc = "Rand's", decimalPlaces = 0, Symbol = "Rand" },
                new Coin { code = "EUR", desc = "Euro", decimalPlaces = 0, Symbol = "EUR" }
            );

            builder.Entity<Unity>().HasData(
                new Unity { code = "UN", desc = "Unidades", round = 2 }
            );

            #endregion
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<AgnusCrm.Models.Invent.Branch> Branch { get; set; }

        public DbSet<AgnusCrm.Models.Invent.Warehouse> Warehouse { get; set; }

        public DbSet<AgnusCrm.Models.Invent.Product> Product { get; set; }

        public DbSet<AgnusCrm.Models.Invent.Vendor> Vendor { get; set; }

        public DbSet<AgnusCrm.Models.Invent.VendorLine> VendorLine { get; set; }

        public DbSet<AgnusCrm.Models.Invent.PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<AgnusCrm.Models.Invent.PurchaseOrderLine> PurchaseOrderLine { get; set; }

        public DbSet<AgnusCrm.Models.Invent.Customer> Customer { get; set; }

        public DbSet<AgnusCrm.Models.Invent.CustomerLine> CustomerLine { get; set; }

        public DbSet<AgnusCrm.Models.Invent.SalesOrder> SalesOrder { get; set; }

        public DbSet<AgnusCrm.Models.Invent.SalesOrderLine> SalesOrderLine { get; set; }

        public DbSet<AgnusCrm.Models.Invent.Shipment> Shipment { get; set; }

        public DbSet<AgnusCrm.Models.Invent.ShipmentLine> ShipmentLine { get; set; }

        public DbSet<AgnusCrm.Models.Invent.Receiving> Receiving { get; set; }

        public DbSet<AgnusCrm.Models.Invent.ReceivingLine> ReceivingLine { get; set; }

        public DbSet<AgnusCrm.Models.Invent.TransferOrder> TransferOrder { get; set; }

        public DbSet<AgnusCrm.Models.Invent.TransferOrderLine> TransferOrderLine { get; set; }

        public DbSet<AgnusCrm.Models.Invent.TransferOut> TransferOut { get; set; }

        public DbSet<AgnusCrm.Models.Invent.TransferOutLine> TransferOutLine { get; set; }

        public DbSet<AgnusCrm.Models.Invent.TransferIn> TransferIn { get; set; }

        public DbSet<AgnusCrm.Models.Invent.TransferInLine> TransferInLine { get; set; }

        public DbSet<AgnusCrm.Models.Crm.Rating> Rating { get; set; }

        public DbSet<AgnusCrm.Models.Crm.Activity> Activity { get; set; }

        public DbSet<AgnusCrm.Models.Crm.Channel> Channel { get; set; }

        public DbSet<AgnusCrm.Models.Crm.Stage> Stage { get; set; }

        public DbSet<AgnusCrm.Models.Crm.AccountExecutive> AccountExecutive { get; set; }

        public DbSet<AgnusCrm.Models.Crm.Lead> Lead { get; set; }

        public DbSet<AgnusCrm.Models.Crm.LeadLine> LeadLine { get; set; }

        public DbSet<AgnusCrm.Models.Crm.Opportunity> Opportunity { get; set; }

        public DbSet<AgnusCrm.Models.Crm.OpportunityLine> OpportunityLine { get; set; }


        public DbSet<Brand> Brand { get; set; }

        public DbSet<Family> Family { get; set; }

        public DbSet<SubFamily> SubFamily { get; set; }

        public DbSet<View_PriceList> View_PriceList { get; set; }

        public DbSet<ProductPrice> ProductPrice { get; set; }

        public DbSet<Unity> Unity { get; set; }

        public DbSet<Coin> Coin { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Entity> Entity { get; set; }

        public DbSet<Contact_Entity> Contact_Entity { get; set; }

        public DbSet<ViewPriceList> ViewPriceList { get; set; }
    }
}
