using OnlineStore.Models.Domain;
using System.Xml.Linq;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>() 
        { 
            new Product() { Id = 0, Name = "P1" },
            new Product() { Id = 1, Name = "P2" },
            new Product() { Id = 2, Name = "P3" }
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
