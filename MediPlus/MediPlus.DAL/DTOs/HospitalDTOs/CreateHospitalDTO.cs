using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.DAL.DTOs.HospitalDTOs
{
    public class CreateHospitalDTO
    {

        public string Name { get; set; }

        public List<int> DoctorHospitals { get; set; }
    }
}
