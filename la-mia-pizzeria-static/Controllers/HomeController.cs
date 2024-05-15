using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
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
            List<Pizza> pizze = new List<Pizza>
            {
                new Pizza("Margherita", "Una pizza classica con mozzarella, pomodoro, basilico", "~/img/margherita.jpg", 5.99m),
                new Pizza("Pizza alla Marinara", "Semplice e deliziosa, con pomodoro, aglio, origano e olio extravergine di oliva.", "~/img/marinara.jpg", 4.99m),
                new Pizza("Pizza alla Diavola", "Una pizza piccante con salame piccante, peperoncino e mozzarella.", "~/img/diavola.jpg", 6.49m),
                new Pizza("Pizza con Mortadella, Stracchino e Pesto", "Una combinazione di mortadella, stracchino e pesto", "~/img/mortadella&stracchino.jpg", 7.99m),
                new Pizza("Pizza Capricciosa", "Una pizza classica con prosciutto cotto, funghi, carciofi, olive e mozzarella.", "~/img/capricciosa.jpg", 8.99m),
                new Pizza("Salsiccia e Friarielli", "Una pizza tipica della tradizione napoletana, con salsiccia e friarielli, condita con mozzarella di bufala e pomodoro San Marzano.", "~/img/salsiccia&friarielli.jpg", 8.99m)
            };

            return View(pizze); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
