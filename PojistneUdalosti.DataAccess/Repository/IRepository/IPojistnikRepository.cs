using PojistneUdalosti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistneUdalosti.DataAccess.Repository.IRepository
{
    public interface IPojistnikRepository : IRepository<Pojistnik>
    {
        void Update(Pojistnik pojistnik);
    }
}
