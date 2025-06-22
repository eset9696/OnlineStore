
using Microsoft.Data.SqlClient;
using OnlineStore.Models.Entities;

namespace OnlineStore.Data.Repositories.Implementations
{
    public class UserReviewRepository : BaseRepository, IUserReviewRepository
    {
        public UserReviewRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Review> GetByProductId(long productId)
        {
            List<Review> reviews = new List<Review>();

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Id, ProductId, Author, Content, Raiting FROM Reviews WHERE ProductId = @productId;";
                cmd.Parameters.AddWithValue("productId", productId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    return reviews;
                }

                while (reader.Read())
                {
                    Review review = new Review()
                    {
                        Id = reader.GetInt64(0),
                        ProductId = productId,
                        Author = reader.GetString(2),
                        Content = reader.GetString(3),
                        Raiting = reader.GetInt16(4)
                    };
                    reviews.Add(review);
                }
            }
            return reviews;
        }
    }
}
