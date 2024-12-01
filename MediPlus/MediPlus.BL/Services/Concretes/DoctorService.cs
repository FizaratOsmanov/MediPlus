using MediPlus.BL.Services.Abstractions;
using MediPlus.DAL.Contexts;
using MediPlus.DAL.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.BL.Services.Concretes
{
    public class DoctorService:IDoctorService
    {
        private readonly MediPlusDbContext _mediPlusDbContext;
        public DoctorService(MediPlusDbContext mediPlusDbContext)
        {
            _mediPlusDbContext = mediPlusDbContext;
        }

        public void CreateDoctor(Doctor doctor)
        {
            _mediPlusDbContext.Doctors.Add(doctor);

            int rows=_mediPlusDbContext.SaveChanges();
            if (rows != 1)
            {
                throw new Exception("Something went wrong");
            }
        }

        public Doctor? GetDoctorById(int id)
        {

            Doctor? doctor=_mediPlusDbContext.Doctors.Find(id);
            if (doctor != null)
            {
                throw new Exception("Doctor is not found");
            }
            return doctor;

        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors=_mediPlusDbContext.Doctors.ToList();
            return doctors;
        }

        public void UpdateDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                throw new Exception("Id is wrong");
            }

            Doctor? baseDoctor = _mediPlusDbContext.Doctors.Find(id);
            if (baseDoctor == null)
            {
                throw new Exception($"Doctor is not found with this ID {id}");
            }
            baseDoctor.Name = doctor.Name;
            baseDoctor.Surname = doctor.Surname;
            baseDoctor.FIN=doctor.FIN;
            baseDoctor.PhoneNumber = doctor.PhoneNumber;
            baseDoctor.Email = doctor.Email;
            baseDoctor.UserName = doctor.UserName;
            baseDoctor.IsActive = doctor.IsActive;
            _mediPlusDbContext.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            Doctor? doctor = _mediPlusDbContext.Doctors.Find(id);
            if (doctor == null)
            {
                throw new Exception("Doctor is not found");

            }
            _mediPlusDbContext.Doctors.Remove(doctor);
        }

    }
}
