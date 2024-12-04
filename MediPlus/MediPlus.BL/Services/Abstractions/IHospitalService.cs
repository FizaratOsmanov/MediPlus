using MediPlus.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPlus.BL.Services.Abstractions
{
    public interface IHospitalService
    {
        public void CreateHospital(Hospital hospital);
        public Hospital? GetHospitalById(int id);

        public List<Hospital> GetAllHospitals();
        public void UpdateHospital(int id, Hospital hospital);
        public void DeleteHospital(int id);
    }
}
