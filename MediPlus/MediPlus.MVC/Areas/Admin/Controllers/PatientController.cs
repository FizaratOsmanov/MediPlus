using MediPlus.BL.Services.Abstractions;
using MediPlus.BL.Services.Concretes;
using MediPlus.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {

        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public IActionResult Patient()
        {
            List<Patient>? patients = _patientService.GetAllPatients();
            return View(patients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            _patientService.CreatePatient(patient);
            return RedirectToAction(nameof(Index));
        }
    }
}
