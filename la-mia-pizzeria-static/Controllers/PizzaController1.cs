using System.Linq;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzaDbContext _dbContext;

        public PizzaController(PizzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            if (!_dbContext.Pizzas.Any())
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

                _dbContext.Pizzas.AddRange(pizze);
                _dbContext.SaveChanges();
            }

            var pizzeList = _dbContext.Pizzas.ToList();

            return View(pizzeList);
        }


        
        public IActionResult Show(int id)
        {
            var pizza = _dbContext.Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

    }
}
