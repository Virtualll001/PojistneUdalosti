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
        [StringLength(100)]
        public string Ulice { get; set; }
        [Required]
        [DisplayName("Číslo")]
        public int Cislo { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Město")]
        public string Mesto { get; set; }
        [DisplayName("Směrovací číslo")]      
        public int SmerovaciCislo { get; set; }
        [Required]
        [DisplayName("Telefonní číslo")]
        [Range(6,12)]
        public int TelefonCislo { get; set; }

        //propojení s tabulkou pojištění
        [Required]       
        public int PojisteniId { get; set; }
        [ForeignKey("PojisteniId")]
        public Pojisteni Pojisteni { get; set; }       
        
    }
}
