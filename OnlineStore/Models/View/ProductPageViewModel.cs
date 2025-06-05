using OnlineStore.Models.Domain;

namespace OnlineStore.Models.View
{
    public class ProductPageViewModel
    {
        public Product CurrentProduct { get; set; }
        public Review? NewReview { get; set; }
        public LinkedList<Review>? ProductReviews { get; set; }

    }
}
