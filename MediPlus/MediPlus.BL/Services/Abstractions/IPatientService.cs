using MediPlus.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.BL.Services.Abstractions
{
    
    public interface IPatientService
    {

        public void CreatePatient(Patient patient);
        public Patient? GetPatientById(int id);
        public List<Patient> GetAllPatients();
        public void UpdatePatient(int id, Patient patient);
        public void DeletePatientint(int id);
    }
}
