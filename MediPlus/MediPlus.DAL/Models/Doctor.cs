﻿using MediPlus.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.DAL.Models
{
    public class Doctor:BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FIN { get; set; }
        public string PhoneNumber { get; set; }
            
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<DoctorHospital>? DoctorHospitals { get; set; }

    }
}
