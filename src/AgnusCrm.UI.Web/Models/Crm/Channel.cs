using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Models.Crm
{
    public class Channel : INetcoreBasic
    {
        public Channel()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Channel Id")]
        public string channelId { get; set; }

        [StringLength(50)]
        [Display(Name = "Channel Name")]
        [Required]
        public string channelName { get; set; }

        [StringLength(50)]
        [Display(Name = "Channel Description")]
        public string description { get; set; }

        [StringLength(10)]
        [Display(Name = "Color Hex")]
        public string colorHex { get; set; }
    }
}
