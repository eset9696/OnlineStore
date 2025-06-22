using OnlineStore.Models.Domain;

namespace OnlineStore.Services
{
    public interface IReviewService
    {
        public List<Review> GetReviews(long ProductId);

        public void AddReview(string author, string? content, byte rating, long productId);

    }
}
