using MediPlus.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.DAL.Contexts
{
    public class MediPlusDbContext : IdentityDbContext<AppUser>
    {

        public MediPlusDbContext(DbContextOptions opt) : base(opt)
        {

        }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<DoctorHospital> DoctorHospitals{ get;set;}

    }
}
