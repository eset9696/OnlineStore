using OnlineStore.Models.Domain;

namespace OnlineStore.Services
{
    public interface IReviewService
    {
        public LinkedList<Review> GetProductReviews(int productId);
        public void AddReview(Review review);
    }
}
