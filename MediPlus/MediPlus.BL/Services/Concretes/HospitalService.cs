using MediPlus.BL.Services.Abstractions;
using MediPlus.DAL.Contexts;
using MediPlus.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.BL.Services.Concretes
{
    public class HospitalService:IHospitalService
    {
        private readonly MediPlusDbContext _mediPlusDbContext;
        public HospitalService(MediPlusDbContext mediPlusDbContext)
        {
            _mediPlusDbContext = mediPlusDbContext;
        }

        public void CreateHospital(Hospital hospital)
        {
            _mediPlusDbContext.Hospitals.Add(hospital);

            int rows = _mediPlusDbContext.SaveChanges();
            if (rows != 1)
            {
                throw new Exception("Something went wrong");
            }
        }
        public Hospital? GetHospitalById(int id)
        {

            Hospital? hospital = _mediPlusDbContext.Hospitals.Find(id);
            if (hospital != null)
            {
                throw new Exception("Doctor is not found");
            }
            return hospital;

        }
        public List<Hospital> GetAllHospitals()
        {
            List<Hospital> hospitals = _mediPlusDbContext.Hospitals.ToList();
            return hospitals;
        }
        public void UpdateHospital(int id, Hospital hospital)
        {
            if (id != hospital.Id)
            {
                throw new Exception("Id is wrong");
            }

            Hospital? baseHospital = _mediPlusDbContext.Hospitals.Find(id);
            if (baseHospital == null)
            {
                throw new Exception($"Hospital is not found with this ID {id}");
            }
            baseHospital.Name = hospital.Name;
            baseHospital.UpdateAt = DateTime.Now;
            _mediPlusDbContext.SaveChanges();
        }
        public void DeleteHospital(int id)
        {
            Hospital? hospital = _mediPlusDbContext.Hospitals.Find(id);
            if (hospital == null)
            {
                throw new Exception("Hospital is not found");

            }
            _mediPlusDbContext.Hospitals.Remove(hospital);
        }
    }
}
