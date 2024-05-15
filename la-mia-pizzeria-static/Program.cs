using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Aggiungi servizi al container.
            builder.Services.AddDbContext<PizzaDbContext>(options =>
                options.UseSqlServer("Data Source=localhost;Initial Catalog=db_la_pizzeria;Integrated Security=True;Trust Server Certificate=True"));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configura la pipeline delle richieste HTTP.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Pizza}/{action=Index}/{id?}");

            app.Run();
        }

    }
}
