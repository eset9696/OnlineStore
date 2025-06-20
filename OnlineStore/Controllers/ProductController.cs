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
            Product currentProduct = _productService.GetProductById(id);

            if (currentProduct == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ProductPageViewModel pPVM = new ProductPageViewModel()
            {
                CurrentProduct = currentProduct,
                Reviews = _reviewService.GetReviews(id)
            };
            
            return View(pPVM);
        }

        [HttpPost]
        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult CreateReview(string Author, string? Content, int Rating, int ProductId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            _reviewService.AddReview(Author, Content, Rating, ProductId);

            return RedirectToAction("Index", new { id = ProductId});
        }
    }
}
