using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Models.Crm
{
    public class Activity : INetcoreBasic
    {
        public Activity()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Activity Id")]
        public string activityId { get; set; }

        [StringLength(50)]
        [Display(Name = "Activity Name")]
        [Required]
        public string activityName { get; set; }

        [StringLength(50)]
        [Display(Name = "Activity Description")]
        public string description { get; set; }

        [StringLength(10)]
        [Display(Name = "Color Hex")]
        public string colorHex { get; set; }
    }
}
