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
    public class Udalost
    {
        [Key]
        public int UdalostId { get; set; }
        [Required]
        public string Popis { get; set; }
        public string Foto { get; set; }//odebrat
        public string ImageUrl { get; set; }
        [Required]
        [DisplayName("Stav")]
        public string Potvrzeno { get; set; }
        
        [Required]
        public int PojistnikId { get; set; }
        [ForeignKey("PojistnikId")]
        public Pojistnik Pojistnik { get; set; }
    }
}
