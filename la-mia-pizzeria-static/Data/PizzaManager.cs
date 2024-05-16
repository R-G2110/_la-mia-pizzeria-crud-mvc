using la_mia_pizzeria_static.Models;
using System.Collections.Generic;
using System.Linq;

namespace la_mia_pizzeria_static.Data
{
    public static class PizzaManager
    {
        private static readonly PizzaDbContext _context = new PizzaDbContext();

        public static int CountAllPizzas()
        {
            return _context.Pizzas.Count();
        }

        public static List<Pizza> GetAllPizzas()
        {
            using (PizzaDbContext db = new PizzaDbContext())
            {
                return db.Pizzas.OrderByDescending(p => p.Id).ToList();
            }
        }

        public static Pizza GetPizza(int id)
        {
            return _context.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public static void InsertPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }

        public static void Seed()
        {
            if (PizzaManager.CountAllPizzas() == 0)
            {
                PizzaManager.InsertPizza(new Pizza("Margherita", "Una pizza classica con mozzarella, pomodoro, basilico", "~/img/margherita.jpg", 5.99m));
                PizzaManager.InsertPizza(new Pizza("Marinara", "Semplice e deliziosa, con pomodoro, aglio, origano e olio extravergine di oliva.", "~/img/marinara.jpg", 4.99m));
                PizzaManager.InsertPizza(new Pizza("Diavola", "Una pizza piccante con salame piccante, peperoncino e mozzarella.", "~/img/diavola.jpg", 6.49m));
                PizzaManager.InsertPizza(new Pizza("Mortadella, Stracchino e Pesto", "Una combinazione di mortadella, stracchino e pesto", "~/img/mortadella&stracchino.jpg", 7.99m));
                PizzaManager.InsertPizza(new Pizza("Capricciosa", "Una pizza classica con prosciutto cotto, funghi, carciofi, olive e mozzarella.", "~/img/capricciosa.jpg", 8.99m));
                PizzaManager.InsertPizza(new Pizza("Salsiccia e Friarielli", "Una pizza tipica della tradizione napoletana, con salsiccia e friarielli, condita con mozzarella di bufala e pomodoro San Marzano.", "~/img/salsiccia&friarielli.jpg", 8.99m));
            }
        }
    }
}
