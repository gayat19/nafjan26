using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary.Interfaces
{
    public interface IAppointmentService
    {
        public List<Appointment> GetAllAppointments();
        public Appointment? GetAppointmentById(int id);
    }
}
