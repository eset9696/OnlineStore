using OnlineStore.Models.Domain;

namespace OnlineStore.Data.Repositories
{
    public interface IProductRepository
    {
        Product? GetProductById(long id);
        List<Product> GetAllProducts();
    }
}
