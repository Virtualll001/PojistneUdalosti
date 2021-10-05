using Microsoft.AspNetCore.Mvc;
using PojistneUdalosti.DataAccess.Repository.IRepository;
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


        //API calls (funguje u MVC)
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Pojisteni.GetAll();
            return Json(new { data = allObj });
        }
        #endregion
    }
}
