using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PojistneUdalosti.DataAccess.Repository.IRepository;
using PojistneUdalosti.Models;
using PojistneUdalosti.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PojistneUdalosti.Areas.Pojistnik.Controllers
{
    [Area("Pojistnik")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Pojisteni> seznamPojist = _unitOfWork.Pojisteni.GetAll(); //NEFACHÁ: (includeProperties: "Pojistnik,Udalost");              
            return View(seznamPojist);
        }

        public IActionResult Info()
        {
            return View();
        }
              

        public IActionResult Poznamky()
        {
            return View();
        }
    }
}
