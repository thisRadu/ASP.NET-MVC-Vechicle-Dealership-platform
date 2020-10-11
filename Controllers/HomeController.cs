using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;
using Bazar.Models;



namespace WebApplication2.Controllers
{
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
      
        public IActionResult DeleteCar(int id)
        {
            Main.RemoveCar(id);
            return RedirectToAction("Index");
        }
        public IActionResult SellCar()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult SellCar(CarModel car)
        {
          
            DatabaseOperation.InsertCar(car);
            return RedirectToAction("Index");
        }
        public IActionResult CarDetails(int id)
        {
            ViewBag.Id = id;
            return View();
         

        }
     
   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
