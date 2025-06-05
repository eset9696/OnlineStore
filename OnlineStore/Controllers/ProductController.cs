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
        ProductPageViewModel productPageViewModel = new ProductPageViewModel();
        
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
            ProductPageViewModel productPageViewModel = new ProductPageViewModel()
            {
                CurrentProduct = _productService.GetProductById(id),
                ProductReviews = _reviewService.GetProductReviews(id)
            };
            //productPageViewModel.;
            //productPageViewModel.ProductReviews = _reviewService.GetProductReviews(id);

            if (productPageViewModel.CurrentProduct == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(productPageViewModel);
        }
        [HttpPost]
        public IActionResult AddReview()
        {
            //_reviewService.AddReview();

            //Console.WriteLine(productPageViewModel.NewReview.Author);
            return RedirectToAction("Index", "Product");
        }

    }
}
