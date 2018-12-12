using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AgnusCrm.Web.Models;

namespace AgnusCrm.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductPrice>()
                .HasKey(a => new { a.product, a.coin, a.unity });

            

            //builder.Entity<SubFamily>()
            //    .HasKey(a => new { a.code, a.familyCode });

            #region GeneralSeed

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
        
        public DbSet<Product> Product { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Family> Family { get; set; }

        public DbSet<SubFamily> SubFamily { get; set; }

        public DbSet<View_PriceList> View_PriceList { get; set; }

        public DbSet<ProductPrice> ProductPrice { get; set; }

        public DbSet<Unity> Unity { get; set; }

        public DbSet<Coin> Coin { get; set; }

        public DbSet<AgnusCrm.Web.Models.Item> Item { get; set; }

        public DbSet<AgnusCrm.Web.Models.Customer> Customer { get; set; }
    }
}
