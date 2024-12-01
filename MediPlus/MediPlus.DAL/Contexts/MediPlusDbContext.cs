﻿using MediPlus.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.DAL.Contexts
{
    public class MediPlusDbContext:DbContext
    {

        public MediPlusDbContext(DbContextOptions opt) : base(opt)
        {

        }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }    

        public DbSet<Appointment> Appointments { get; set; }
    }
}
