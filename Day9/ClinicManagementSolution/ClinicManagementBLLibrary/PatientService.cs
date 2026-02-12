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
    public class PatientService : IPatientService, IAppointmentService
    {
        private readonly IRepository<int, Patient> _patientRepository;
        private readonly IRepository<int, Appointment> _appointmentRepository;
        private readonly IDoctorService _doctorService;

        public PatientService(IRepository<int,Patient> patientRepository, 
            IRepository<int,Appointment> appointmentRepository,
            IDoctorService doctorService) 
        {
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
            _doctorService = doctorService;
        }
        public Patient Add(Patient patient)
        {
            var result =  _patientRepository.Add(patient);
            if (result != null)
                return result;
            throw new Exception("Failed to add patient");
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            try
            {
                var ifDoctorExists = _doctorService.GetAllDoctors().Any(d => d.Id == appointment.DoctorId);
                if (!ifDoctorExists)
                    throw new Exception("Doctor does not exist");
                var ifPatientExists = _patientRepository.GetAll().Any(p => p.Id == appointment.PatientId);
                if (!ifPatientExists)
                    throw new Exception("Patient does not exist");
                var appointmnets = _appointmentRepository.GetAll();
                if (appointmnets != null)
                {
                    var ifAppointmentExists = _appointmentRepository.GetAll().Any(a => a.AppointmnetNumber == appointment.AppointmnetNumber);

                    if (ifAppointmentExists)
                        throw new AppointUnAvailableException("The selected time is already taken");
                }
                var result = _appointmentRepository.Add(appointment);
                if (result != null)
                    return result;
                throw new Exception("Failed to add appointment");

            }
            catch(NullReferenceException ex)
            {
                throw new Exception("Failed to add appointment. " + ex.Message);
            }

        }

        public List<Appointment> GetAllAppointments(int userid)
        {
            var appointments = _appointmentRepository.GetAll();

            if (appointments == null || appointments.Count() == 0)
                throw new NoItemsInCollectionException("No appointments found");
            appointments = appointments
                            .Where(a => a.Status != "Cancelled" && a.DoctorId == userid)
                            .OrderByDescending(a => a.AppointmnetDate);

            return appointments.Count() > 0 ? appointments.ToList() : throw new NoItemsInCollectionException("No appointments found");
        }

        public Appointment? GetAppointmentById(int id)
        {
            var appointment = _appointmentRepository.Get(id);
            if (appointment == null)
                throw new ItemNotFoundException(id);
            return appointment;
        }

        public Patient UpdatePhone(int patientId, string newPhone)
        {
            var patient = _patientRepository.Get(patientId);
            if (patient == null)
                throw new ItemNotFoundException(patientId);
            patient.Phone = newPhone;
            var result = _patientRepository.Update(patientId,patient);
            return result != null ? result : throw new Exception("Failed to update patient phone number");
        }
    }
}
