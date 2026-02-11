using ClinicManagementBLLibrary.Interfaces;
using ClinicManagementDALLibrary.Interfaces;
using ClinicManagementModelsLibrary;

namespace ClinicManagementBLLibrary
{
    public class SpecialityService : ISpecialityService
    {
        private readonly IRepository<int, Speciality> _repository;

        public SpecialityService(IRepository<int,Speciality> repository) 
        {
            _repository = repository;
        }
        public bool AddSpeciality(Speciality speciality)
        {
            var isDuplicate = GetSpecialityByName(speciality.Name) != null;
            if (isDuplicate)
                return false;
            var result = _repository.Add(speciality);
            //return result != null;
            if(result != null)
                return true;
            else
                return false;
        }

        public List<Speciality> GetAllSpecialities()
        {
            var result = _repository.GetAll();
            if (result != null)
                return result.ToList();
            throw new Exception("No Specialities in the collection");
        }

        public Speciality? GetSpecialityById(int id)
        {
            throw new NotImplementedException();
        }

        public int? GetSpecialityByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
