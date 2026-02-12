using ClinicManagementBLLibrary.Exceptions;
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
            bool specialityAdded = false;
            if (doctor.Speciality != null && _specialityService.AddSpeciality(doctor.Speciality))
            {
                doctor.SpecialityId = doctor.Speciality.Id;
                doctor.Speciality = null;
                specialityAdded = true;
            }
            else
                specialityAdded = true;
            var result = _doctorRepository.Add(doctor);
            if ( result != null && specialityAdded)
                return true;
            if(result!=null && !specialityAdded)
                throw new PartialAddException("Failed to add speciality. Doctor added");
            if(result == null && specialityAdded)
                throw new Exception("Failed to add doctor. But added speciality");
            throw new Exception("Failed to add doctor and speciality");
        }

        public List<Appointment> GetAllAppointments()
        {
            var appointments = _appointmentRepository.GetAll();
           
            if (appointments == null || appointments.Count() == 0)
                throw new NoItemsInCollectionException("No appointments found");
            appointments = appointments
                            .Where(a=>a.Status != "Cancelled")
                            .OrderByDescending(a => a.AppointmnetDate);
            //LINQ as query syntax
            //var appointments = from a in _appointmentRepository.GetAll()
            //                   where a.Status != "Cancelled"
            //                   orderby a.AppointmnetDate descending

            return appointments.Count()>0? appointments.ToList(): throw new NoItemsInCollectionException("No appointments found");
        }

        public List<Doctor> GetAllDoctors()
        {
           var doctors = _doctorRepository.GetAll();
            if (doctors == null || doctors.Count() == 0)
                throw new NoItemsInCollectionException("No doctors found");
            return doctors.ToList();
        }

  

        public Appointment? GetAppointmentById(int id)
        {
            var appointment = _appointmentRepository.Get(id);
            if (appointment == null)
                throw new ItemNotFoundException(id);
            return appointment;
        }

        public Doctor? GetDoctorById(int id)
        {
            var doctor = _doctorRepository.Get(id);
            if (doctor == null)
                throw new ItemNotFoundException(id);
            return doctor;
        }

        public List<Doctor> GetDoctorsBySpeciality(string name)
        {
           var specialityId = _specialityService.GetSpecialityByName(name);
            if (specialityId == null)
                throw new ItemNotFoundException();
            var doctors = _doctorRepository.GetAll();
            if(doctors == null)
                throw new NoItemsInCollectionException($"No doctors found with speciality {name}");
            doctors = doctors.Where(d => d.SpecialityId == specialityId);
            if (doctors == null || doctors.Count() == 0)
                throw new NoItemsInCollectionException($"No doctors found with speciality {name}");
            return doctors.ToList();
        }

        public bool UpdateDoctor(int id, int? experience, string? speciality)
        {
           var doctor = _doctorRepository.Get(id);
            if (doctor == null)
                throw new ItemNotFoundException(id);
            if (experience != null)
                doctor.Experience = experience.Value;
            if (speciality != null)
            {
                var specialityId = _specialityService.GetSpecialityByName(speciality);
                if (specialityId == null)
                    throw new ItemNotFoundException();
                doctor.SpecialityId = specialityId.Value;
            }
            var result = _doctorRepository.Update(id,doctor);
            return result != null;
        }
    }
}
