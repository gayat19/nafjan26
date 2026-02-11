using ClinicManagementModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementBLLibrary.Interfaces
{
    public interface ISpecialityService
    {
        public List<Speciality> GetAllSpecialities();
        public Speciality? GetSpecialityById(int id);
        public int? GetSpecialityByName(string name);
        public bool AddSpeciality(Speciality speciality);

    }
}
