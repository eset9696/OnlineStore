using Microsoft.Data.SqlClient;
using OnlineStore.Models.Domain;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineStore.Services.Implementations
{
    public class ReviewService : IReviewService
    {

        private readonly string? _connectionString;

        public ReviewService(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        
        public void AddReview(string name, string? content, int rating, long productId)
        {
            Review newReview = new Review()
            {
                ProductId = productId,
                Author = name,
                Content = content,
                Rating = rating,
                CreatedAt = DateTime.Now,
            };
            //_reviews.Add(newReview);
        }

        public List<Review> GetReviews(long productId)
        {

            List<Review> reviews = new List<Review>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = @$"SELECT * FROM Reviews WHERE ProductId = {productId}";

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Review review = new Review()
                    {
                        Id = reader.GetInt64(0),
                        ProductId = reader.GetInt64(1),
                        Author = reader.GetString(2),
                        Content = reader.GetString(3),
                        Rating = (int)reader.GetByte(4),
                        CreatedAt = reader.GetDateTime(5)
                    };
                    reviews.Add(review);
                }
            }

            return reviews;
            /*List<Review> lastReviews = new List<Review>(_reviews).Where(review => review.ProductId == productId).ToList();
            lastReviews.Reverse();
            return lastReviews;*/
        }

        /*public long NextId()
        {
            long maxId = 0;
            foreach (Review review in _reviews)
            {
                if (review.Id > maxId)
                {
                    maxId = review.Id;
                }
            }
            return ++maxId;
        }*/
    }
}
