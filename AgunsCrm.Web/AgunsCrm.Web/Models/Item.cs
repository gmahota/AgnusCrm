using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Web.Models
{
    public class Item
    {
        [Key]
        public int id { get; set; }

        public int productId { get; set; }

        [Display (Name ="Preço")]
        public double price { get; set; }

        [Display(Name ="Qnt.")]
        public int quantity { get; set; }

        [ForeignKey("productId")]
        public Product Product { get; set; }

        
    }
}
