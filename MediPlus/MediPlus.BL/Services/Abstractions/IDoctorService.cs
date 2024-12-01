using MediPlus.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.BL.Services.Abstractions
{
    public interface IDoctorService
    {
        public void CreateDoctor(Doctor doctor);
        public Doctor? GetDoctorById(int id);

        public List<Doctor> GetAllDoctors();
        public void UpdateDoctor(int id, Doctor doctor);
        public void DeleteDoctor(int id);
    }
}
