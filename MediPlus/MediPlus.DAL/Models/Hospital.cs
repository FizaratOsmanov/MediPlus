using MediPlus.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.DAL.Models
{
    public class Hospital:BaseAuditableEntity
    {
        public string Name { get; set; }

        public ICollection<DoctorHospital>? DoctorHospitals { get; set; }
    }
}
