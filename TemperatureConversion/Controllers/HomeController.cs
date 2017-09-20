using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemperatureConversion.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["C"] = 0;
            ViewData["F"] = 32;
            return View();
        }

        public ActionResult Convert(FormCollection form)
        {
            string choice;
            double celcius, fahrenheit;
          
            choice = form["temp"];
           
            if (choice == "Celcius to Fahernheit")
            {
                double.TryParse(form["celcius"], out celcius);
                fahrenheit = celcius * 9 / 5 + 32;
                ViewData["F"] = Math.Round(fahrenheit,2);
            }

            if (choice == "Fahrenheit to Celcius")
            {
                double.TryParse(form["fahrenheit"], out fahrenheit);
                celcius = (fahrenheit - 32) * 5.0 / 9;
                ViewData["C"] = Math.Round(celcius, 2);
            }
            else ViewData["Error"] = "Invalid Selection";
           
            return View("Index");
        }
    }
}