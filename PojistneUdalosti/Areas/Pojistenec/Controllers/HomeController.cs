using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PojistneUdalosti.Models;
using PojistneUdalosti.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PojistneUdalosti.Areas.Pojistenec.Controllers
{
    [Area("Pojistenec")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
