using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Domain;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;

        public ProductController(IProductService productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
        }

        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult Index(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Product? product = _productService.GetProductById(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(product);
        }
        [Route("{controller}/Feedback/{action}/{id:int?}")]
        public IActionResult GetFeedBack(int id)
        {
            FeedbackPageViewModel feedbackPageViewModel = new FeedbackPageViewModel();
            feedbackPageViewModel.Reviews = _reviewService.GetReviews(id);
            return View(feedbackPageViewModel);
        }

    }
}
