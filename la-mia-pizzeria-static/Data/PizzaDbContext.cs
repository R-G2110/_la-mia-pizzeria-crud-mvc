using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Data
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public const string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=db_la_pizzeria;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }

    }
}

