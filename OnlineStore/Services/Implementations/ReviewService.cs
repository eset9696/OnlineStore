using OnlineStore.Models.Domain;

namespace OnlineStore.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly List<Review> _reviewList = new List<Review>()
        { 
            new Review(){Id = 0, ProductId = 0, Author = "Dan99", Rating = 5, ReviewText = "Good stuff"},
            new Review(){Id = 1, ProductId = 1, Author = "Mike12", Rating = 4, ReviewText = "Good choise"},
            new Review(){Id = 2, ProductId = 2, Author = "Ivan2020", Rating = 2, ReviewText = "shit!!!!!"},
            new Review(){Id = 3, ProductId = 3, Author = "Sam87", Rating = 3, ReviewText = "I'm to old for this shit"},
        };
        public void AddReview(Review review)
        {
            _reviewList.Add(review);
        }

        public LinkedList<Review> GetReviews(int productId)
        {
            LinkedList<Review> reviews = new LinkedList<Review>();
            foreach (Review review in _reviewList)
            {
                if(review.ProductId == productId)
                {
                    reviews.AddFirst(review);
                }
            }
            return reviews;
        }
        public int NextId()
        {
            int maxId = 0;
            foreach (Review review in _reviewList)
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
