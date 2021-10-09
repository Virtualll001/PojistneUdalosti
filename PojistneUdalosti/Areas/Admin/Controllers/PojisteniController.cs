using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
    public class PojisteniController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public PojisteniController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if(files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"img\pojisteni");
                    var extension = Path.GetExtension(files[0].FileName);

                    if(pojisteni.ImageUrl != null)
                    {
                        //EDIT - a je třeba odebrat starý obrázek
                        var imagePath = Path.Combine(webRootPath, pojisteni.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using(var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    pojisteni.ImageUrl = @"\img\pojisteni\" + fileName + extension; //nezapomínat zpětné lomítko na konci! "pojisteni\"!
                }
                else
                {
                    //EDIT - ale obrázek se nemění (není tam a není třeba odebrat)
                    if(pojisteni.PojisteniId != 0)
                    {
                        Pojisteni objFromDb = _unitOfWork.Pojisteni.Get(pojisteni.PojisteniId);
                        pojisteni.ImageUrl = objFromDb.ImageUrl;
                    }
                }

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
