using ClinicManagementBLLibrary;
using ClinicManagementBLLibrary.Interfaces;
using ClinicManagementDALLibrary;
using ClinicManagementDALLibrary.Interfaces;
using ClinicManagementModelsLibrary;

namespace ClinicManagementApp
{
    internal class Program
    {
        IDoctorService doctorService;
        IPatientService patientService;
        IAppointmentService doctorAppointmentService;
        IAppointmentService patientAppointmentService;
        ISpecialityService specialityService;
        Program()
        {
            IRepository<int, Doctor> doctorRepository = new DoctorRepository();
            IRepository<int, Patient> patientRepository = new PatientRepository();
            IRepository<int, Appointment> appointmentRepository = new AppointmentRepository();
            IRepository<int, Speciality> specialityRepository = new SpecialityRepository();
            specialityService = new SpecialityService(specialityRepository);
            doctorService = new DoctorService(doctorRepository, appointmentRepository, specialityService);
            patientService = new PatientService(patientRepository, appointmentRepository,  doctorService);
            doctorAppointmentService = new DoctorService(doctorRepository, appointmentRepository, specialityService);
            patientAppointmentService = new PatientService(patientRepository, appointmentRepository,  doctorService);
        }
        void PrrofOfWork()
        {
           try
            {
                var speciality = specialityService.AddSpeciality(new Speciality { Name = "Cardiology" });
                var doctor = new Doctor { Name = "Dr. Smith", Experience = 10, SpecialityId = specialityService.GetSpecialityByName("Cardiology") ?? 0 };
                var patient = new Patient { Name = "John", Phone = "9876543210" };
                doctorService.AddDoctor(doctor);
                patientService.Add(patient);
                var appointment = new Appointment
                {
                    DoctorId = doctor.Id,
                    PatientId = patient.Id,
                    AppointmnetDate = DateTime.Now.AddDays(1),
                    Status = "Scheduled"
                };
                patientService.AddAppointment(appointment);
                    var doctorAppointments = doctorAppointmentService.GetAllAppointments(doctor.Id);
                    Console.WriteLine($"Appointments for {doctor.Name}:");
                    foreach (var app in doctorAppointments)
                    {
                        Console.WriteLine($"Appointment ID: {app.AppointmnetNumber}, Patient ID: {app.PatientId}, Date: {app.AppointmnetDate}, Status: {app.Status}");
                }
                Console.WriteLine("Trying to duplicate appointmnet");
                patientService.AddAppointment(appointment);


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("All done");
        }

        static void Main(string[] args)
        {
           new Program().PrrofOfWork();
        }
    }
}
