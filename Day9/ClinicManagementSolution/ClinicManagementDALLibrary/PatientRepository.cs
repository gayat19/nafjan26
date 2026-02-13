using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementDALLibrary
{
    public class PatientRepository : Repository<int, Patient>
    {
        public override Patient? Get(int key)
        {
            var patient = clinicContext.Patients.Find(key);
            return patient;

        }

        public override IEnumerable<Patient>? GetAll()
        {
            var patients = clinicContext.Patients;
            if (patients == null || patients.Count() == 0)
                return null;
            return patients;
        }
    }
}
