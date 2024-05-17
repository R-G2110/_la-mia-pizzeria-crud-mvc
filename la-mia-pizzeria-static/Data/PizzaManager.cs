using la_mia_pizzeria_static.Models;
using System.Collections.Generic;
using System.Linq;

namespace la_mia_pizzeria_static.Data
{
    public static class PizzaManager
    {
        public static int CountAllPizzas()
        {
            using (PizzaDbContext db = new PizzaDbContext())
            {
                return db.Pizzas.Count();
            }
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
            using (PizzaDbContext db = new PizzaDbContext())
            {
                return db.Pizzas.FirstOrDefault(p => p.Id == id);
            }
        }

        public static void InsertPizza(Pizza pizza)
        {
            using (PizzaDbContext db = new PizzaDbContext())
            {
                db.Pizzas.Add(pizza);
                db.SaveChanges();
            }
        }

        public static void UpdatePizza(Pizza pizza)
        {
            using (PizzaDbContext db = new PizzaDbContext())
            {
                db.Pizzas.Update(pizza);
                db.SaveChanges();
            }
        }

        public static void DeletePizza(int id)
        {
            using (PizzaDbContext db = new PizzaDbContext())
            {
                var pizza = db.Pizzas.FirstOrDefault(p => p.Id == id);
                if (pizza != null)
                {
                    db.Pizzas.Remove(pizza);
                    db.SaveChanges();
                }
            }
        }

        public static void Seed()
        {
            using (PizzaDbContext db = new PizzaDbContext())
            {
                if (db.Pizzas.Count() == 0)
                {
                    db.Pizzas.AddRange(
                        new Pizza("Margherita", "Una pizza classica con mozzarella, pomodoro, basilico", "~/img/margherita.jpg", 5.99m),
                        new Pizza("Marinara", "Semplice e deliziosa, con pomodoro, aglio, origano e olio extravergine di oliva.", "~/img/marinara.jpg", 4.99m),
                        new Pizza("Diavola", "Una pizza piccante con salame piccante, peperoncino e mozzarella.", "~/img/diavola.jpg", 6.49m),
                        new Pizza("Mortadella, Stracchino e Pesto", "Una combinazione di mortadella, stracchino e pesto", "~/img/mortadella&stracchino.jpg", 7.99m),
                        new Pizza("Capricciosa", "Una pizza classica con prosciutto cotto, funghi, carciofi, olive e mozzarella.", "~/img/capricciosa.jpg", 8.99m),
                        new Pizza("Salsiccia e Friarielli", "Una pizza tipica della tradizione napoletana, con salsiccia e friarielli, condita con mozzarella di bufala e pomodoro San Marzano.", "~/img/salsiccia&friarielli.jpg", 8.99m)
                    );
                    db.SaveChanges();
                }
            }
        }
    }
}
