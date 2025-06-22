using Microsoft.Data.SqlClient;
using OnlineStore.Data.Repositories;
using OnlineStore.Models.Domain;
using System.Data;
using System.Xml.Linq;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Product? GetProductById(long id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        /*public bool AddProducts(List<Product> products)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                SqlTransaction transaqtion = connection.BeginTransaction();

                try
                {
                    foreach (Product product in products)
                    {
                        SqlCommand cmd = connection.CreateCommand();
                        cmd.Transaction = transaqtion;
                        cmd.CommandText = $"INSERT INTO Products (Name, Price) VALUES (@name, 100)";
                        cmd.Parameters.Add("name", SqlDbType.NVarChar, 128).Value = product.Name;

                        cmd.ExecuteNonQuery();
                    }
                    transaqtion.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaqtion.Rollback();
                }
            }
            return false;
        }*/
    }
}
