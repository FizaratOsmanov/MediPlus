using MediPlus.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.DAL.Models
{
    public class Appointment :BaseAuditableEntity
    {


        public int DoctorId { get; set; } 
        
        public Doctor? Doctor { get; set; }

        public int PatientId {  get; set; }

        public Patient? Patient { get; set; }

        public DateTime? AppointmentDate { get; set; }

    }
}
