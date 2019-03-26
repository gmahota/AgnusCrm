using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Models.Crm
{
    public class Rating : INetcoreBasic
    {
        public Rating()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Rating Id")]
        public string ratingId { get; set; }

        [StringLength(50)]
        [Display(Name = "Rating Name")]
        [Required]
        public string ratingName { get; set; }

        [StringLength(50)]
        [Display(Name = "Rating Description")]
        public string description { get; set; }

        [StringLength(10)]
        [Display(Name = "Color Hex")]
        public string colorHex { get; set; }
    }
}
