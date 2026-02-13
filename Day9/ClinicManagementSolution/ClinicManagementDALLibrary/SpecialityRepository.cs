using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementDALLibrary
{
    public class SpecialityRepository : Repository<int, Speciality>
    {
        public override Speciality? Get(int key)
        {
            var speciality =clinicContext.Specialities.SingleOrDefault(s=> s.Id == key);
            return speciality;
        }

        public override IEnumerable<Speciality>? GetAll()
        {
            var specialities = clinicContext.Specialities;
            if (specialities == null || !specialities.Any())
                return null;
            return specialities;
        }
    }
}
