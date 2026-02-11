using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary.Interfaces
{
    public interface IDoctorService
    {
        public List<Doctor> GetAllDoctors();
        public Doctor? GetDoctorById(int id);
        public List<Doctor> GetDoctorsBySpeciality(string name);
        public bool AddDoctor(Doctor doctor);
        public bool UpdateDoctor(int id, int? experience, string? speciality);
        public List<Patient> GetAllPatients();


    }
}
