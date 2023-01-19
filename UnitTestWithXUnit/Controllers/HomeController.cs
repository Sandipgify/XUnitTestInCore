using Microsoft.AspNetCore.Mvc;

namespace UnitTestWithXUnit.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddClient()
        {
            return View();
        }
    }
}
