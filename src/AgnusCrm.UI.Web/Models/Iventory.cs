using AgnusCrm.Models.Invent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Models
{
    public class Item
    {
        [Key]
        public string id { get; set; }

        public string productCode { get; set; }

        [Display(Name = "Preço")]
        public double price { get; set; }

        [Display(Name = "Qnt.")]
        public int quantity { get; set; }

        [ForeignKey("productId")]
        public Product Product { get; set; }
    }

    #region Iventario

    public enum ProductStatusTypes
    {
        Active,
        Promotion,
        Inactive
    }
    
    //public partial class Product
    //{
    //    [Key]
    //    public int id { get; set; }

    //    [Required]
    //    [StringLength(100)]
    //    [Display(Name = "Codigo")]
    //    public string code { get; set; }

    //    [StringLength(100)]
    //    [Display(Name = "Descrição")]
    //    public string desc { get; set; }

    //    [Required]
    //    [Range(0, 9999999)]
    //    [Display(Name = "Preço")]
    //    public double price { get; set; }

        

    //    [Display(Name = "Observações")]
    //    public string notes { get; set; }

    //    [Required]
    //    [Range(0, 9999999)]
    //    [Display(Name = "Stock")]
    //    public double stock { get; set; }

    //    [Required]
    //    [Display(Name = "Status")]
    //    [DefaultValue(ProductStatusTypes.Active)]
    //    public ProductStatusTypes status { get; set; }

    //    [ForeignKey("familyCode")]
    //    [Display(Name = "Famila")]
    //    public virtual Family Family { get; set; }

    //    [ForeignKey("subFamilyCode")]
    //    [Display(Name = "Sub-Famila")]
    //    public virtual SubFamily SubFamily { get; set; }

    //    [ForeignKey("brandCode")]
    //    [Display(Name = "Marca")]
    //    public virtual Brand Brand { get; set; }

    //    public IList<ProductPrice> ProductPrice { get; set; }
    //}

    public partial class ProductPrice
    {
        [Required]
        [Display(Name = "Producto")]
        public string productCode { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Moeda")]
        public string coin { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Unidades")]
        public string unity { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP1")]
        public double pvp1 { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP2")]
        public double pvp2 { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP3")]
        public double pvp3 { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP4")]
        public double pvp4 { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP5")]
        public double pvp5 { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP6")]
        public double pvp6 { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP1 Iva Incluido?")]
        public bool pvp1VatInclude { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP2 Iva Incluido?")]
        public bool pvp2VatInclude { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP3 Iva Incluido?")]
        public bool pvp3VatInclude { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP4 Iva Incluido?")]
        public bool pvp4VatInclude { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP5 Iva Incluido?")]
        public bool pvp5VatInclude { get; set; }

        [Range(0, 9999999)]
        [Display(Name = "PVP6 Iva Incluido?")]
        public bool pvp6VatInclude { get; set; }

        [ForeignKey("productCode")]
        public Product Product { get; set; }

        [ForeignKey("coin")]
        public Coin Coin { get; set; }

        [ForeignKey("unity")]
        public Unity Unity { get; set; }
    }

    public partial class Family
    {
        [Key]
        [Display(Name = "Famila")]
        [StringLength(20)]
        public string code { get; set; }

        [StringLength(50)]
        [Display(Name = "Descrição (Familias)")]
        public string description { get; set; }

        public virtual List<Product> listProducts { get; set; }
        public virtual List<SubFamily> listSubFamilys { get; set; }

    }

    public class SubFamily
    {
        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Sub-Familia")]
        [StringLength(20)]
        public string code { get; set; }

        [Display(Name = "Descrição (Sub-Famila)")]
        [StringLength(50)]
        public string description { get; set; }

        [StringLength(20)]
        public string familyCode { get; set; }

        [ForeignKey("familyCode")]
        public virtual Family family { get; set; }

    }

    public class Brand
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "Marca")]
        public string code { get; set; }

        [Display(Name = "Descrição (Marca)")]
        [StringLength(50)]
        public string description { get; set; }

        public virtual List<Product> listProducts { get; set; }
    }
    #endregion

    public class View_PriceList
    {
        [Key]
        [Display(Name = "Artigo")]
        public string artigo { get; set; }

        public string marca { get; set; }

        [Display(Name = "Marca")]
        public string marca_Desc { get; set; }

        public string familia { get; set; }

        [Display(Name = "Descrição (Familias)")]
        public string familia_Desc { get; set; }

        public string subFamilia { get; set; }

        [Display(Name = "Sub Familia")]
        public string subFamilia_Desc { get; set; }

        [Display(Name = "Descrição (Artigos)")]
        public string artigo_Desc { get; set; }

        [Display(Name = "Preço")]
        public double preco { get; set; }

        [Display(Name = "Stock")]
        public double stock { get; set; }
    }
}
