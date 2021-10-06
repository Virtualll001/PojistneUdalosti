using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistneUdalosti.Models
{
    public class Pojistnik
    {
        [Key]
        public int PojistnikId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Jméno")]
        public string Jmeno { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Příjmení")]
        public string Prijmeni { get; set; }
        [Required]       
        public string Adresa { get; set; }       
        [Required]
        [DisplayName("Telefonní číslo")]        
        public int TelefonCislo { get; set; }

        //propojení s tabulkou pojištění (tabulka Událost je propojená s tabulkou pojištění)
        [Required]       
        public int PojisteniId { get; set; }
        [ForeignKey("PojisteniId")]
        public Pojisteni Pojisteni { get; set; }         

    }
}
