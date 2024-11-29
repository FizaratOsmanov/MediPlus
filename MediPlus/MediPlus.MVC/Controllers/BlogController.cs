using Microsoft.AspNetCore.Mvc;

namespace MediPlus.MVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
