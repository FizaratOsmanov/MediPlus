using Microsoft.AspNetCore.Mvc;

namespace MediPlus.MVC.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
