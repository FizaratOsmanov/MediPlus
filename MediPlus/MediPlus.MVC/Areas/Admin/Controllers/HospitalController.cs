using MediPlus.BL.Services.Abstractions;
using MediPlus.BL.Services.Concretes;
using MediPlus.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediPlus.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Manager")]
    public class HospitalController : Controller
    {
        private readonly IHospitalService _hospitalService;
        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        public IActionResult Hospital()
        {

            List<Hospital>? hospitals=_hospitalService.GetAllHospitals();
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Doctors = _hospitalService.Doctors;
            ViewBag.Doctors = new SelectList(_hospitalService.Doctors);
            return View();
        }


        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            _hospitalService.CreateHospital(hospital);
            return RedirectToAction(nameof(Index));
        }
    }
}
