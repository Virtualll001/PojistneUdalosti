using PojistneUdalosti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistneUdalosti.DataAccess.Repository.IRepository
{
    public interface IUdalostRepository : IRepository<Udalost>
    {
        void Update(Udalost udalost);
    }
}
