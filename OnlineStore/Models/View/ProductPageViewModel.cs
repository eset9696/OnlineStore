using OnlineStore.Models.Domain;

namespace OnlineStore.Models.View
{
    public class ProductPageViewModel
    {
        public required Product CurrentProduct { get; set; }

        public Review? NewReview { get; set; }

        public List<int> NewReviewRating = new List<int>() { 5, 4, 3, 2, 1 };
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
