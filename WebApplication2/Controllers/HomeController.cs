using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bazar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace Bazar.Controllers
{
    public class HomeController : Controller
    {
        public IStringLocalizer<Resource> localizer;

        public HomeController(IStringLocalizer<Resource> localizer)
        {
            this.localizer = localizer;
        }

        public IActionResult SetCulture(string culture, string sourceUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            return Redirect(sourceUrl);
        }

        public IActionResult Index()
        {
      
            return View();
        }
        
        [Authorize]
        public IActionResult DeleteCar(int id)
        {
            Main.RemoveCar(id);
            return RedirectToAction("Index");
        }
        public IActionResult SellCar()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult SellCar(CarModel car)
        { 
            if (string.IsNullOrEmpty(car.Marca)) { ModelState.AddModelError("Marca", "Te rugam sa introduci o valoare!");}
            if (string.IsNullOrEmpty(car.Modelul)) { ModelState.AddModelError("Modelul", "Te rugam sa introduci o valoare!"); }
            if (string.IsNullOrEmpty(car.Anul.ToString())) { ModelState.AddModelError("Anul", "Te rugam sa introduci o valoare!"); }
            if (string.IsNullOrEmpty(car.Volumul.ToString())) { ModelState.AddModelError("Volumul", "Te rugam sa introduci o valoare!"); }
            if (string.IsNullOrEmpty(car.Puterea.ToString())) { ModelState.AddModelError("Puterea", "Te rugam sa introduci o valoare!"); }
            if (string.IsNullOrEmpty(car.Combustibilul)) { ModelState.AddModelError("Combustibilul", "Te rugam sa introduci o valoare!"); }
            if (string.IsNullOrEmpty(car.Caroseria)) { ModelState.AddModelError("Caroseria", "Te rugam sa introduci o valoare!"); }
            if (string.IsNullOrEmpty(car.Fotografia)) { ModelState.AddModelError("Fotografia", "Te rugam sa introduci o valoare!"); }
            if (string.IsNullOrEmpty(car.Descriere)) { ModelState.AddModelError("Descriere", "Te rugam sa introduci o valoare!"); }
            if (string.IsNullOrEmpty(car.Pretul.ToString())) { ModelState.AddModelError("Pretul", "Te rugam sa introduci o valoare!"); }
            if (string.IsNullOrEmpty(car.Contact)) { ModelState.AddModelError("Contact", "Te rugam sa introduci o valoare!"); }



            if  (ModelState.IsValid) { 
                DatabaseOperation.InsertCar(car);
                return RedirectToAction("Index");
            }
            else return View();
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
