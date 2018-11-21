
namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; } = "Watersports";
        public Product Related { get; set; }
        public bool NameBeginsWithS => Name?[0] == 'S'; //Uso de expresión lambda para obtener valor variable de las propiedades

        public static Product[] GetProducts()
        {
            Product kayak = new Product()
            {
                Name = "Kayak",
                Price = 275M,
                Category = "Water Craft"
            };

            Product lifeJacket = new Product
            {
                Name = "Lifejacket",
                Price = 48.95M
            };

            kayak.Related = lifeJacket;
            return new Product[] { kayak, lifeJacket, null };
        }
    }
}
