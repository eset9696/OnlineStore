using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Domain;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
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
