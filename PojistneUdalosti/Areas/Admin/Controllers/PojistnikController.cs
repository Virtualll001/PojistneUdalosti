using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PojistneUdalosti.DataAccess.Repository.IRepository;
using PojistneUdalosti.Models;
using PojistneUdalosti.Models.ViewModels;
using System.Linq;

namespace PojistneUdalosti.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PojistnikController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public PojistnikController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            PojistnikVM pojistnikVM = new PojistnikVM()
            {
                Pojistnik = new Pojistnik(),
                SeznamPojisteni = _unitOfWork.Pojisteni.GetAll().Select(i => new SelectListItem {
                    Text = i.TypPojisteni,                    
                    Value = i.PojisteniId.ToString()
                })
            };


            if(id == null) //jde o CREATE
            {
                return View(pojistnikVM);
            }
            //jde o EDIT
            pojistnikVM.Pojistnik = _unitOfWork.Pojistnik.Get(id.GetValueOrDefault());
            if(pojistnikVM.Pojistnik == null)
            {
                return NotFound();
            }
            return View(pojistnikVM);            
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
                return RedirectToAction(nameof(Index)); //nepoužívat "magic-string" např.: "Index"
            }
            return View(pojistnik);
        }

        //API calls (funguje u MVC)
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Pojistnik.GetAll(includeProperties:"Pojisteni");
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
