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
        public string TypPojisteni { get; set; }       
        [Required]
        [DisplayName("Podmínky")]
        public string Podminky { get; set; }
        [Required]
        [Range(50, 5000)]
        [DisplayName("Měsíční záloha")]
        public double Zaloha { get; set; }       
    }
}
