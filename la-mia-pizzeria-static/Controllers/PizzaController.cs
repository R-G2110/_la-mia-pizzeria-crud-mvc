using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View(PizzaManager.GetAllPizzas());
        }

        public IActionResult GetPizza(int id)
        {
            var pizza = PizzaManager.GetPizza(id);
            if (pizza != null)
                return View(pizza);
            else
                return View("errore");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                PizzaManager.InsertPizza(pizza);
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        // Aggiungi altre azioni come Modifica e Cancella secondo necessità
    }
}
