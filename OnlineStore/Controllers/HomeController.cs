using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Domain;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("{controller}")]
        [Route("{controller}/{action}")]
        public IActionResult Index([FromServices] IProductService productService)
        {
            HomePageViewModel viewModel = new HomePageViewModel()
            {
                Products = productService.GetProducts()
            };
            return View(viewModel);
        }
    }
}
