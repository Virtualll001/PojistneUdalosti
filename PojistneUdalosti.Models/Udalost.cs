using System;
using System.Collections.Generic;
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
        public string Foto { get; set; }
        [Required]
        public bool Potvrzeno { get; set; }
        
        [Required]
        public int PojisteniId { get; set; }
        [ForeignKey("PojisteniId")]
        public Pojisteni Pojisteni { get; set; }
    }
}
