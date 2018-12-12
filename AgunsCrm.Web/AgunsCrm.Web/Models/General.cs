using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Web.Models
{
    public class General
    {
    }

    #region General
    public partial class Coin
    {
        [System.ComponentModel.DataAnnotations.Key]
        [StringLength(3)]
        [Display(Name = "Codigo")]
        public string code { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descrição")]
        public string desc { get; set; }

        [StringLength(5)]
        public string Symbol { get; set; }

        [DefaultValue(2)]
        [Display(Name = "Nr. Casas Decimais")]
        public int decimalPlaces { get; set; }

        public string logo { get; set; }
    }

    public partial class Unity
    {
        [Key]
        [Required]
        [StringLength(5)]
        [Display(Name = "Unidade")]
        public string code { get; set; }

        [StringLength(50)]
        [Display(Name = "Descrição")]
        public string desc { get; set; }

        [DefaultValue(2)]
        [Display(Name = "Arredondamento")]
        public int round { get; set; }
    }

    #endregion

}
