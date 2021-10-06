using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistneUdalosti.Models.ViewModels
{
    public class PojistnikVM
    {
        public Pojistnik Pojistnik { get; set; }
        public IEnumerable<SelectListItem> SeznamPojisteni { get; set; }
    }
}
