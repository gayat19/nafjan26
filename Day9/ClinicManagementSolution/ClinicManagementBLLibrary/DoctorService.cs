using ClinicManagementBLLibrary.Interfaces;
using ClinicManagementDALLibrary;
using ClinicManagementDALLibrary.Interfaces;
using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary
{
    public class DoctorService : IDoctorService, IAppointmentService
    {
        private readonly IRepository<int, Doctor> _doctorRepository;
        private readonly IRepository<int, Appointment> _appointmentRepository;
        private readonly ISpecialityService _specialityService;

        public DoctorService(IRepository<int,Doctor> doctorRepository,
            IRepository<int,Appointment> appointmentRepository,
            ISpecialityService specialityService)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
            _specialityService = specialityService;
        }
        public bool AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Appointment? GetAppointmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor? GetDoctorById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorsBySpeciality(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDoctor(int id, int? experience, string? speciality)
        {
            throw new NotImplementedException();
        }
    }
}
