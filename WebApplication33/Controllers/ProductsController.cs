using Microsoft.AspNetCore.Mvc;

namespace WebApplication33.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
