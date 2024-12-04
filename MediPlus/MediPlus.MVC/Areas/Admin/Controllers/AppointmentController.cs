using MediPlus.BL.Services.Abstractions;
using MediPlus.BL.Services.Concretes;
using MediPlus.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin,Manager")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Appointment()
        {
            List<Appointment>? appointments = _appointmentService.GetAllAppointments();
            return View(appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            _appointmentService.CreateAppointment(appointment);
            return RedirectToAction(nameof(Index));
        }
    }
}
