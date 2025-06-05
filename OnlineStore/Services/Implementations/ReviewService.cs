using OnlineStore.Models.Domain;

namespace OnlineStore.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private List<Review> _reviews = new List<Review>();
        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }

        public LinkedList<Review> GetProductReviews(int productId)
        {
            LinkedList<Review> productReviews = new LinkedList<Review>();

            foreach(Review review in _reviews)
            {
                if(review.ProductId == productId) productReviews.AddFirst(review);
            }
            return productReviews;
        }
    }
}
