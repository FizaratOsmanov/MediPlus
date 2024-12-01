using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.DAL.Models
{
    public class Appointment
    {

        public int Id { get; set; }

        public int DoctorId { get; set; } 
        
        public Doctor? Doctor { get; set; }

        public int PatientId {  get; set; }

        public Patient? Patient { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

    }
}
