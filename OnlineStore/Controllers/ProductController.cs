using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Domain;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
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

        /*public IActionResult AddProducts(Product[] products)
        {
            bool isSuccess = _productService.AddProducts(new List<Product>(products));
            if (!isSuccess)
            {
                return BadRequest();
            }
            return Ok();
        }*/
    }
}
