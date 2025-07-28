using Microsoft.AspNetCore.Mvc;

namespace skylance_backend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
