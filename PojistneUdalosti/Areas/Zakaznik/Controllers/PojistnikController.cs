using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PojistneUdalosti.DataAccess.Repository.IRepository;
using PojistneUdalosti.Models;

namespace PojistneUdalosti.Areas.Zakaznik.Controllers
{
    [Area("Zakaznik")]
    public class PojistnikController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PojistnikController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Pojistnik pojistnik = new Pojistnik();
            /*
            {
                Pojistnik=new Pojistnik(),
                SeznamPojisteni = _unitOfWork.Pojisteni.GetAll().Select(i => new SelectListItem {
                    Text = i.TypPojisteni,                    
                    Value = i.PojisteniId.ToString()
                })
            };*/

            if (id == null) //jde o CREATE
            {
                return View(pojistnik);
            }
            //jde o EDIT
            pojistnik = _unitOfWork.Pojistnik.Get(id.GetValueOrDefault());
            if(pojistnik == null)
            {
                return NotFound();
            }
            return View(pojistnik);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Pojistnik pojistnik)
        {            
            if (ModelState.IsValid)
            {
                if (pojistnik.PojistnikId == 0)
                {
                    _unitOfWork.Pojistnik.Add(pojistnik);                   
                }
                else
                {
                    _unitOfWork.Pojistnik.Update(pojistnik);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index)); //nepoužívat "magic-string"
            }
            /*
            else
            {
                pojistnikVM.SeznamPojisteni = _unitOfWork.Pojisteni.GetAll().Select(i => new SelectListItem
                {
                    Text = i.TypPojisteni,
                    Value = i.PojisteniId.ToString()
                });
                if(pojistnikVM.Pojistnik.PojistnikId != 0)
                {
                    pojistnikVM.Pojistnik = _unitOfWork.Pojistnik.Get(pojistnikVM.Pojistnik.PojistnikId);
                }
            }*/
            return View(pojistnik);
        }

        //API calls (funguje u MVC)
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Pojistnik.GetAll();//includeProperties:"Pojisteni"
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Pojistnik.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Odstranění se nezdařilo." });
            }
            _unitOfWork.Pojistnik.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Odstranění proběhlo úspěšně." });
        }
        #endregion
    }
}
