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
    public class UdalostRepository : Repository<Udalost>, IUdalostRepository
    {
        private readonly ApplicationDbContext _db;
        public UdalostRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Udalost udalost)
        {
            var objFromDb = _db.Udalost.FirstOrDefault(s => s.UdalostId == udalost.UdalostId);
            
            if(objFromDb!=null)
            {                
                if(udalost.Foto != null)
                {
                    objFromDb.Foto = udalost.Foto;
                }  
                objFromDb.Popis = udalost.Popis;                
                objFromDb.Potvrzeno = udalost.Potvrzeno;
                objFromDb.PojistnikId = udalost.PojistnikId;                               
            }            
        }
    }
}
