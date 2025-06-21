using Microsoft.Data.SqlClient;
using OnlineStore.Models.Domain;
using System.Xml.Linq;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly string _connectionString;
        public ProductService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public Product? GetProductById(long id)
        {
            foreach (Product item in GetProducts()) 
            {
                if(item.Id == id) return item;
            }
            return null;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Products;";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product item = new Product()
                    {
                        Id = reader.GetInt64(0),
                        Name = reader.GetString(1)
                    };
                    products.Add(item);
                }
            }

            return products;
        }
    };
}
