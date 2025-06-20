using OnlineStore.Models.Domain;

namespace OnlineStore.Services
{
    public interface IReviewService
    {
        public List<Review> GetReviews(int ProductId);

        public void AddReview(string name, string? content, int rating, int productId);

        public int NextId();
    }
}
