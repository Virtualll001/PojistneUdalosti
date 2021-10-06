using PojistneUdalosti.DataAccess.Data;
using PojistneUdalosti.DataAccess.Repository.IRepository;
using PojistneUdalosti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistneUdalosti.DataAccess.Repository
{
    
    public class PojistnikRepository : Repository<Pojistnik>, IPojistnikRepository
    {
        private readonly ApplicationDbContext _db;
        public PojistnikRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Pojistnik pojistnik)
        {
            var objFromDb = _db.Pojistnik.FirstOrDefault(s => s.PojistnikId == pojistnik.PojistnikId);
            
            if(objFromDb!=null)
            {
                objFromDb.Jmeno = pojistnik.Jmeno;
                objFromDb.Prijmeni = pojistnik.Prijmeni;
                objFromDb.Adresa = pojistnik.Adresa;              
                objFromDb.TelefonCislo = pojistnik.TelefonCislo;
                objFromDb.PojisteniId = pojistnik.PojisteniId;                              
            }
        }
    }
}
