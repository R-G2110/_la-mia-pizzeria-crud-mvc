using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View(PizzaManager.GetAllPizzas());
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            var pizzas = PizzaManager.GetAllPizzas();

            if (!string.IsNullOrEmpty(searchString))
            {
                pizzas = pizzas.Where(p => p.Name.ToLower().Contains(searchString.ToLower()) || p.Description.ToLower().Contains(searchString.ToLower())).ToList();
            }

            if (!pizzas.Any())
            {
                ViewData["SearchMessage"] = $"Nessuna pizza '{searchString}' è stata trovata.";
            }

            return View("Index", pizzas);
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
            ViewBag.Categories = new SelectList(GetCategories(), "Id", "Name");
            return View("PizzaForm", new Pizza());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                PizzaManager.InsertPizza(pizza);
                TempData["SuccessMessage"] = $"La pizza {pizza.Name} è stata creata con successo!";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(GetCategories(), "Id", "Name");
            return View("PizzaForm", pizza);
        }

        public IActionResult Edit(int id)
        {
            var pizza = PizzaManager.GetPizza(id);
            if (pizza != null)
            {
                ViewBag.Categories = new SelectList(GetCategories(), "Id", "Name", pizza.CategoryId);
                return View("PizzaForm", pizza);
            }
            else
            {
                return View("errore");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                PizzaManager.UpdatePizza(pizza);
                TempData["SuccessMessage"] = $"La pizza {pizza.Name} è stata modificata con successo!";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(GetCategories(), "Id", "Name", pizza.CategoryId);
            return View("PizzaForm", pizza);
        }

        public IActionResult Delete(int id)
        {
            var pizza = PizzaManager.GetPizza(id);
            if (pizza == null)
            {
                TempData["ErrorMessage"] = $"La pizza {pizza?.Name} non è stata trovata!";
                return RedirectToAction("Index");
            }

            PizzaManager.DeletePizza(id);
            TempData["SuccessMessage"] = $"La pizza {pizza.Name} è stata eliminata con successo!";
            return RedirectToAction("Index");
        }
        private List<Category> GetCategories()
        {
            using (var db = new PizzaDbContext())
            {
                return db.Categories.ToList();
            }
        }
    }
}