using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary.Interfaces
{
    public interface IPatientService 
    {
        public Patient Add(Patient patient);
        public Patient UpdatePhone(int patientId, string newPhone);
        public Appointment AddAppointment(Appointment appointment);

        
    }
}
