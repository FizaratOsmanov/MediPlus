using MediPlus.BL.Services.Abstractions;
using MediPlus.DAL.Contexts;
using MediPlus.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.BL.Services.Concretes
{
    public class PatientService : IPatientService
    {
        private readonly MediPlusDbContext _mediPlusDbContext;
        public PatientService(MediPlusDbContext mediPlusDbContext)
        {
            _mediPlusDbContext = mediPlusDbContext;
        }

        public void CreatePatient(Patient patient)
        {
            _mediPlusDbContext.Patients.Add(patient);
            int rows = _mediPlusDbContext.SaveChanges();

            if (rows != 1)
            {
                throw new Exception("Something went wrong");

            }
        }

        public Patient? GetPatientById(int id)
        {
            Patient? patient = _mediPlusDbContext.Patients.Find(id);

            return patient;

        }
        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = _mediPlusDbContext.Patients.ToList();
            return patients;
        }

        public void UpdatePatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                throw new Exception("Id is wrong");
            }

            Patient? basePatient = _mediPlusDbContext.Patients.Find(id);

            if (basePatient != null)
            {
                throw new Exception($"Patient in not found with this ID{id}");
            }

            basePatient.Name = patient.Name;
            basePatient.Surname = patient.Surname;
            basePatient.FIN = patient.FIN;
            basePatient.PhoneNumber = patient.PhoneNumber;
            basePatient.Username = patient.Username;
            basePatient.IsDeleted = patient.IsDeleted;
            basePatient.Appointments = patient.Appointments;
            _mediPlusDbContext.SaveChanges();

        }

        public void DeletePatientint (int id)
        {
            Patient? patient = _mediPlusDbContext.Patients.Find(id);
            if (patient == null)
            {
                throw new Exception("Doctor is not found");

            }
            _mediPlusDbContext.Patients.Remove(patient);
        }
    }
}
