using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.DAL.Models
{
    public class DoctorHospital
    {

        public int DoctorId { get; set; }

        public int HospitalId { get; set; }


        public Doctor? Doctor { get; set; }

        public Hospital? Hospital { get; set; }
    }
}
