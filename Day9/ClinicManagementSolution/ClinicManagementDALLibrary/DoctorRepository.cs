using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementDALLibrary
{
    public class DoctorRepository : Repository<int, Doctor>
    {
        public override Doctor? Get(int key)
        {
            var doctor = clinicContext.Doctors.SingleOrDefault(d=>d.Id==key);
            return doctor;
        }

        public override IEnumerable<Doctor>? GetAll()
        {
            var doctors = clinicContext.Doctors;
            if(doctors.Any()) 
                return doctors;
            return null;
        }
    }
}
