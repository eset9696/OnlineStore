using Microsoft.Data.SqlClient;
using OnlineStore.Models.Domain;
using System.Data;

namespace OnlineStore.Data.Repositories.Implementations
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {

        }

        private Product ReadProduct(SqlDataReader reader)
        {
            return new Product()
            {
                Id = reader.GetInt64(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                Price = reader.GetDecimal(3)
            };
        }
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Description, Price FROM Products;";

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product()
                        {
                            Id = Convert.ToInt64(reader["Id"]),
                            Name = reader.GetString(1),
                            Description = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                            Price = reader.GetDecimal(3)
                        };
                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public Product? GetProductById(long id)
        {
            using(SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Description, Price FROM Products WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dataReader = cmd.ExecuteReader();

                if (!dataReader.HasRows)
                    return null;

                dataReader.Read();
                return ReadProduct(dataReader);
            }
        }
    }
}
