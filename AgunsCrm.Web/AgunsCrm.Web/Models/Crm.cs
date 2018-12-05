using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Web.Models
{
    public class CRM
    {
        
    }

    public class Customer
    {
        [Key]
        public int id { get; set; }

        public int entityId { get; set; }

        public string pvp { get; set; }

        [ForeignKey("entityId")]
        public Entity entity { get; set; }
    }

    public class Entity
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Tipo")]
        public string type { get; set; }

        [Display(Name ="Codigo")]
        public string code { get; set; }

        [Display(Name = "Nome")]
        public string name { get; set; }

        [Display(Name = "Morada")]
        public string address { get; set; }

        [Display(Name = "Localidade")]
        public string locality { get; set; }

        [Display(Name ="Nuit")]
        public string contributing_Number { get; set; }

        [Display(Name ="País")]
        public string country { get; set; }

        [Display(Name = "Telefone")]
        public string telphone { get; set; }

        [Display(Name ="Moeda")]
        public string coin { get; set; }
    }

    public class Contact
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string email { get; set; }
        public string emailAlt { get; set; }
        public string type { get; set; }
        public string celphone { get; set; }
        public string telphone { get; set; }
        public string userId { get; set; }

        public List<Contact_Entity> contact_Itens { get; set; }
    }

    

    public class Contact_Entity
    {
        [Key]
        public int id { get; set; }

        public int contactId { get; set; }

        public int entityId { get; set; }

        public string type { get; set; }
        public string name { get; set; }
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
