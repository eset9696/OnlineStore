using OnlineStore.Models.Domain;
using System.Xml.Linq;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>() 
        { 
            new Product() { Id = 0, Name = "MSI RTX 8090 Ti Super" },
            new Product() { Id = 1, Name = "AMD Ryzen 9 9800 X3D" },
            new Product() { Id = 2, Name = "Какой то крутой моник" }
        };
        public Product? GetProductById(int id)
        {
            foreach (Product item in _products) 
            {
                if(item.Id == id) return item;
            }
            return null;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }
    };
}
