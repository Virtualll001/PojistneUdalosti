using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PojistneUdalosti.Models
{
    public class Pojisteni
    {
        [Key]
        public int PojisteniId { get; set; }
        [Required]   
        [StringLength(50)]
        [DisplayName("Typ")]
        public string TypPojisteni { get; set; }       
        [Required]
        [DisplayName("Podmínky")]
        public string Podminky { get; set; }
        [Required]       
        [DisplayName("Záloha")]
        public Double Zaloha { get; set; }       
    }
}
//TODO - dořešit zobrazování čísel