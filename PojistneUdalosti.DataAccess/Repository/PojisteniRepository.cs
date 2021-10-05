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
    //tato třída řeší update - ostatní metody jsou v Repository
    public class PojisteniRepository : Repository<Pojisteni>, IPojisteniRepository
    {
        private readonly ApplicationDbContext _db;
        public PojisteniRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Pojisteni pojisteni)
        {
            var objFromDb = _db.Pojisteni.FirstOrDefault(s => s.PojisteniId == pojisteni.PojisteniId);
            
            if(objFromDb!=null)
            {
                objFromDb.TypPojisteni = pojisteni.TypPojisteni;
                objFromDb.Podminky = pojisteni.Podminky;
                objFromDb.Zaloha = pojisteni.Zaloha;
                _db.SaveChanges();
            }            
        }
    }
}
