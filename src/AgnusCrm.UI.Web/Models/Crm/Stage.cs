using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Models.Crm
{
    public class Stage : INetcoreBasic
    {
        public Stage()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Stage Id")]
        public string stageId { get; set; }

        [StringLength(50)]
        [Display(Name = "Stage Name")]
        [Required]
        public string stageName { get; set; }

        [StringLength(50)]
        [Display(Name = "Stage Description")]
        public string description { get; set; }

        [StringLength(10)]
        [Display(Name = "Color Hex")]
        public string colorHex { get; set; }
    }
}
