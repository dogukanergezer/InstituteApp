using Microsoft.AspNetCore.Mvc;

namespace InstituteApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
