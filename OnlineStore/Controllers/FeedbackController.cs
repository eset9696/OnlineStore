using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Domain;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IProductService _productService;
        private Product product;

        public FeedbackController(IReviewService reviewService, IProductService productService) 
        {
            _reviewService = reviewService;
            _productService = productService;
        }

        [Route("{controller}/{action}/{id:int}")]
        public IActionResult Index(int id)
        {
            FeedbackPageViewModel feedbackPageViewModel = new FeedbackPageViewModel();
            feedbackPageViewModel.Reviews = _reviewService.GetReviews(id);
            product = _productService.GetProductById(id);
            ViewBag.productId = product.Id;
            ViewBag.ProductName = product.Name;
            return View(feedbackPageViewModel);
        }

        [Route("{controller}/{action}/{id:int}")]
        public IActionResult NewReview(int id, string productName)
        {
            ViewBag.productId = id;
            ViewBag.ProductName = productName;
            return View();
        }
        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            review.Id = _reviewService.NextId();
            _reviewService.AddReview(review);
            return RedirectToAction("Index", "Home");
        }
    }
}
