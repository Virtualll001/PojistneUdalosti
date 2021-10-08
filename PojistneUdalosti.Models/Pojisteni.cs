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
        [Range(1, double.MaxValue, ErrorMessage = "Částka musí být větší než 0")]
        public Double Zaloha { get; set; }
        [DisplayName("Obrázek - url")]
        public string ImageUrl { get; set; }
    }
}
