using MediPlus.BL.Services.Abstractions;
using MediPlus.DAL.Contexts;
using MediPlus.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.BL.Services.Concretes
{
    public class AppointmentService :IAppointmentService
    {
        private readonly MediPlusDbContext _mediPlusDbContext;
        public AppointmentService(MediPlusDbContext mediPlusDbContext)
        {
            _mediPlusDbContext = mediPlusDbContext;
        }

        public void CreateAppointment(Appointment appointment)
        {
            _mediPlusDbContext.Appointments.Add(appointment);
            int rows = _mediPlusDbContext.SaveChanges();

            if (rows != 1)
            {
                throw new Exception("Something went wrong");

            }
        }

        public Appointment? GetAppointmentById(int id)
        {
            Appointment? appointment = _mediPlusDbContext.Appointments.Find(id);

            return appointment;

        }
        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = _mediPlusDbContext.Appointments.ToList();
            return appointments;
        }

        public void UpdateAppointment(Appointment appointment)
        {

        }
    }
}
