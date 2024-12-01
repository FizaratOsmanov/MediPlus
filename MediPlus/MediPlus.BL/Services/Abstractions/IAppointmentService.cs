using MediPlus.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.BL.Services.Abstractions
{
    public interface IAppointmentService
    {
        public void CreateAppointment(Appointment appointment);
        public Appointment? GetAppointmentById(int id);

        public List<Appointment> GetAllAppointments();

        public void UpdateAppointment(int id, Appointment appointment);
        public void DeleteAppointment(int id);

    }
}
