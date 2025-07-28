using Microsoft.AspNetCore.Mvc;

namespace skylance_backend.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
