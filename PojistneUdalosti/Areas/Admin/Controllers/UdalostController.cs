using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PojistneUdalosti.DataAccess.Repository.IRepository;
using PojistneUdalosti.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace PojistneUdalosti.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UdalostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment; //nahrání obrázků

        public UdalostController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            Udalost udalost = new Udalost();
            if(id == null) //jde o CREATE
            {
                return View(udalost);
            }
            //jde o EDIT
            udalost = _unitOfWork.Udalost.Get(id.GetValueOrDefault());
            if(udalost == null)
            {
                return NotFound();
            }
            return View(udalost);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Udalost udalost)
        {
            if (ModelState.IsValid)
            {
                //práce se souborem... 
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if(files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"img\udalosti");
                    var extension = Path.GetExtension(files[0].FileName);
                    
                    if(udalost.ImageUrl != null)
                    {
                        //edit - odstranění staré fotky                        
                        var imagePath = Path.Combine(webRootPath, udalost.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using(var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    udalost.ImageUrl = @"\img\udalosti\" + fileName + extension;
                }
                else
                {
                    //update - když se foto nemění
                    if(udalost.UdalostId != 0)
                    {
                        Udalost objFromDb = _unitOfWork.Udalost.Get(udalost.UdalostId);
                        udalost.ImageUrl = objFromDb.ImageUrl;
                    }
                }

                if (udalost.UdalostId == 0)
                {
                    _unitOfWork.Udalost.Add(udalost);
                }
                else
                {
                    _unitOfWork.Udalost.Update(udalost);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index)); //nepoužívat "magic-string"
            }
            return View(udalost);
        }


        //API calls (funguje u MVC)
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Udalost.GetAll(); //vyhozeno: includeProperties:"Pojisteni"
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Udalost.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Odstranění se nezdařilo." });
            }

            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _unitOfWork.Udalost.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Odstranění proběhlo úspěšně." });
        }
        #endregion
    }
}
