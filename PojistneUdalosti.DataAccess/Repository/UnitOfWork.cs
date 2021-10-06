using PojistneUdalosti.DataAccess.Data;
using PojistneUdalosti.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistneUdalosti.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Pojisteni = new PojisteniRepository(_db);
            Pojistnik = new PojistnikRepository(_db);
            Udalost = new UdalostRepository(_db);

            SP_Call = new SP_Call(_db);
        }
        public IPojisteniRepository Pojisteni { get; private set; }
        public IPojistnikRepository Pojistnik { get; private set; }
        public IUdalostRepository Udalost { get; private set; }

        public ISP_Call SP_Call { get; private set; }              

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save() //Repository změny neukládá jen dělá změny = je třeba je uložit touto metodou
        {
            _db.SaveChanges();
        }
    }
}
