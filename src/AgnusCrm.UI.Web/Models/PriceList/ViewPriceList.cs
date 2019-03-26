using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Models.PriceList
{
    public class ViewPriceList
    {
        public int id { get; set; }

        [Display(Name = "Marca")]
        public string brand_desc { get; set; }

        [Display(Name = "Famila")]
        public string family_desc { get; set; }

        [Display(Name = "Sub-Famila")]
        public string subFamily_desc { get; set; }

        [Display(Name = "Descrição")]
        public string desc { get; set; }

        [Display(Name = "Preço")]
        public double price { get; set; }

        [Display(Name = "Stock")]
        public double stock { get; set; }

        [Display(Name = "Encomenda")]
        public bool encomenda { get; set; }
    }
}
