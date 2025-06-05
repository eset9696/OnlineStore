using OnlineStore.Models.Domain;

namespace OnlineStore.Services
{
    public interface IReviewService
    {
        public LinkedList<Review> GetReviews(int ProductId);

        public void AddReview(Review review);
    }
}
