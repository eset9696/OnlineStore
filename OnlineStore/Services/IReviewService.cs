using OnlineStore.Models.Domain;

namespace OnlineStore.Services
{
    public interface IReviewService
    {
        public List<Review> GetReviews(long ProductId);

        public void AddReview(string name, string? content, int rating, long productId);

    }
}
