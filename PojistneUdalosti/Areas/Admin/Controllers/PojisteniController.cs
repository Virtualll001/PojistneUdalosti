using Microsoft.AspNetCore.Mvc;
using PojistneUdalosti.DataAccess.Repository.IRepository;
using PojistneUdalosti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PojistneUdalosti.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PojisteniController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PojisteniController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Pojisteni pojisteni = new Pojisteni();
            if (id == null) //jde o CREATE
            {
                return View(pojisteni);
            }
            //jde o EDIT
            pojisteni = _unitOfWork.Pojisteni.Get(id.GetValueOrDefault());
            if (pojisteni == null)
            {
                return NotFound();
            }
            return View(pojisteni);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Pojisteni pojisteni)
        {
            if (ModelState.IsValid)
            {
                if (pojisteni.PojisteniId == 0)
                {
                    _unitOfWork.Pojisteni.Add(pojisteni);
                }
                else
                {
                    _unitOfWork.Pojisteni.Update(pojisteni);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index)); //nepoužívat "magic-string" např.: "Index"
            }
            return View(pojisteni);
        }

        //API calls (funguje u MVC)
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Pojisteni.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Pojisteni.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Odstranění se nezdařilo." });
            }
            _unitOfWork.Pojisteni.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Odstranění proběhlo úspěšně." });
        }
        #endregion
    }
}
