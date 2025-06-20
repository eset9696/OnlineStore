using OnlineStore.Models.Domain;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineStore.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly List<Review> _reviews = new List<Review>()
        { 
            new Review(){Id = 0, ProductId = 0, Author = "Dan99", Rating = 5, Content = "Good stuff", CreatedAt = DateTime.Now},
            new Review(){Id = 1, ProductId = 1, Author = "Mike12", Rating = 4, Content = "Good choise", CreatedAt = DateTime.Now},
            new Review(){Id = 2, ProductId = 2, Author = "Ivan2020", Rating = 2, Content = "shit!!!!!", CreatedAt = DateTime.Now},
            new Review(){Id = 3, ProductId = 3, Author = "Sam87", Rating = 3, Content = "I'm to old for this shit", CreatedAt = DateTime.Now},
        };
        public void AddReview(string name, string? content, int rating, int productId)
        {
            Review newReview = new Review()
            {
                Id = NextId(),
                ProductId = productId,
                Author = name,
                Content = content,
                Rating = rating,
                CreatedAt = DateTime.Now,
            };
            _reviews.Add(newReview);
        }

        public List<Review> GetReviews(int productId)
        {
            List<Review> lastReviews = new List<Review>(_reviews).Where(review => review.ProductId == productId).ToList();
            lastReviews.Reverse();
            return lastReviews;
        }
        public int NextId()
        {
            int maxId = 0;
            foreach (Review review in _reviews)
            {
                if (review.Id > maxId)
                {
                    maxId = review.Id;
                }
            }
            return ++maxId;
        }
    }
}
