using OnlineStore.Models.Entities;

namespace OnlineStore.Data.Repositories
{
    public interface IUserReviewRepository
    {
        List<Review> GetByProductId(long productId);

    }
}
