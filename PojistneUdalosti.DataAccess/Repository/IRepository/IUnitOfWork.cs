using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistneUdalosti.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPojisteniRepository Pojisteni { get; }
        ISP_Call SP_Call { get; }
    }
}
