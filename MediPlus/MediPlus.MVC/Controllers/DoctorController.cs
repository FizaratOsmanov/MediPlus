using Microsoft.AspNetCore.Mvc;

namespace MediPlus.MVC.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
