namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }

        public Pizza(string nome, string descrizione, string foto, decimal prezzo)
        {
            this.Name = nome;
            this.Description = descrizione;
            this.ImagePath = foto;
            this.Price = prezzo;
        }
    }

}
