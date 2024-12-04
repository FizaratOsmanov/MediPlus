using MediPlus.BL.Services.Abstractions;
using MediPlus.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Manager")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }


        public IActionResult Doctor()
        {
            List<Doctor>?  doctors=_doctorService.GetAllDoctors();
            return View(doctors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            _doctorService.CreateDoctor(doctor);
            return RedirectToAction(nameof(Index));
        }


    }
}
