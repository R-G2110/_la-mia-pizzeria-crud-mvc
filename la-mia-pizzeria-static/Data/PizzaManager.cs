﻿using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;
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
                return db.Pizzas.Include(p => p.Category).OrderByDescending(p => p.Id).ToList();
            }
        }

        public static Pizza GetPizza(int id)
        {
            using (PizzaDbContext db = new PizzaDbContext())
            {
                return db.Pizzas.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
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

        public static void SeedPizza()
        {
            using (PizzaDbContext db = new PizzaDbContext())
            {
                if (db.Pizzas.Count() == 0)
                {
                    db.Pizzas.AddRange(
                        new Pizza("Margherita", "Una pizza classica con mozzarella, pomodoro, basilico", "~/img/margherita.jpg", 5.99m, 1),
                        new Pizza("Marinara", "Semplice e deliziosa, con pomodoro, aglio, origano e olio extravergine di oliva.", "~/img/marinara.jpg", 4.99m, 1),
                        new Pizza("Diavola", "Una pizza piccante con salame piccante, peperoncino e mozzarella.", "~/img/diavola.jpg", 6.49m, 1),
                        new Pizza("Mortadella, Stracchino e Pesto", "Una combinazione di mortadella, stracchino e pesto", "~/img/mortadella&stracchino.jpg", 7.99m, 2),
                        new Pizza("Capricciosa", "Una pizza classica con prosciutto cotto, funghi, carciofi, olive e mozzarella.", "~/img/capricciosa.jpg", 8.99m, 1),
                        new Pizza("Salsiccia e Friarielli", "Una pizza tipica della tradizione napoletana, con salsiccia e friarielli, condita con mozzarella di bufala.", "~/img/salsiccia&friarielli.jpg", 8.99m, 2)
                    );
                    db.SaveChanges();
                }
            }
        }

        public static void SeedCategory()
        {
            using (PizzaDbContext db = new PizzaDbContext())
            {
                if (db.Categories.Count() == 0)
                {
                    db.Categories.AddRange(
                        new Category("Pizze classiche"),
                        new Category("Pizze bianche"),
                        new Category("Pizze vegetariane"),
                        new Category("Pizze di mare"),
                        new Category("Pizze speciali")
                    );
                    db.SaveChanges();
                }
            }
        }
    }
}
