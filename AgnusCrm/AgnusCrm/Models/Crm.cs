using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Models
{
    public class CRM
    {

    }

    public class Customer
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Entidade")]

        public int entityId { get; set; }

        [Display(Name = "PVP")]
        [Range(1, 6)]
        public int pvp { get; set; }

        [ForeignKey("entityId")]
        public Entity entity { get; set; }
    }

    public class Entity
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Tipo")]
        [StringLength(20)]
        public string type { get; set; }

        [Display(Name = "Codigo")]
        [StringLength(20)]
        public string code { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50)]
        public string name { get; set; }

        [Display(Name = "Morada")]
        [StringLength(100)]
        public string address { get; set; }

        [Display(Name = "Localidade")]
        [StringLength(20)]
        public string locality { get; set; }

        [Display(Name = "Nuit")]
        [StringLength(20)]
        public string contributing_Number { get; set; }

        [Display(Name = "País")]
        [StringLength(20)]
        public string country { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(30)]
        public string telphone { get; set; }

        [Display(Name = "Moeda")]
        [StringLength(3)]
        public string coin { get; set; }

        [ForeignKey("coin")]
        public Coin Coin { get; set; }

        public virtual IList<Contact_Entity> listContact { get; set; }
    }

    public class Contact
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Code")]
        [StringLength(20)]
        public string code { get; set; }

        [Display(Name = "Nome Completo")]
        [StringLength(100)]
        public string fullName { get; set; }

        [Display(Name = "Primeiro Nome")]
        [StringLength(50)]
        public string firstName { get; set; }

        [Display(Name = "Nome Do Meio")]
        [StringLength(50)]
        public string middleName { get; set; }

        [Display(Name = "Ultimo Nome")]
        [StringLength(50)]
        public string lastName { get; set; }

        [Display(Name = "Titulo")]
        [StringLength(10)]
        public string title { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Email Alternativo")]
        [StringLength(50)]
        public string emailAlt { get; set; }

        [Display(Name = "Tipo")]
        [StringLength(20)]
        public string type { get; set; }

        [Display(Name = "Celular")]
        [StringLength(20)]
        public string cellPhone { get; set; }

        [Display(Name = "Celular")]
        [StringLength(20)]
        public string telephone { get; set; }

        [Display(Name = "Utilizador")]
        public string userId { get; set; }

        public ContactStatus Status { get; set; }

        public List<Contact_Entity> contact_Itens { get; set; }
    }

    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }

    public class Contact_Entity
    {
        [Key]
        public int id { get; set; }

        public int contactId { get; set; }

        public int entityId { get; set; }

        [Display(Name = "Tipo")]
        [StringLength(20)]
        public string type { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [StringLength(20)]
        public string value { get; set; }

        [ForeignKey("contactId")]
        public Contact contact { get; set; }

        [ForeignKey("entityId")]
        public Entity entity { get; set; }
    }

    public class Report
    {
        [Key]
        public int id { get; set; }
        public string empresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string tipoEntidade { get; set; }
        public string entidade { get; set; }
        public string caminho { get; set; }
        public string to { get; set; }
        public string cc { get; set; }

    }
}
