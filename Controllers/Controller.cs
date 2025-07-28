using Microsoft.AspNetCore.Mvc;

namespace skylance_backend.Controllers
{
    public class Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
