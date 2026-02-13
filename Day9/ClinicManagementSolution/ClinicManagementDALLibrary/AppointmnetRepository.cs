using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementDALLibrary
{
    public class AppointmentRepository : Repository<int, Appointment>
    {
        public override Appointment? Get(int key)
        {
           var item = clinicContext.Appointments.SingleOrDefault(a=>a.AppointmnetNumber == key);
            return item;
        }

        public override IEnumerable<Appointment>? GetAll()
        {
            var appointments = clinicContext.Appointments;
            if (appointments == null || appointments.Count() == 0)
                return null;
            return appointments;
        }
    }
}
