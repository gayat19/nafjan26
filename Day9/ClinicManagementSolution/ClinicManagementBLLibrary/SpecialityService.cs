using ClinicManagementBLLibrary.Exceptions;
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
            if(_repository.GetAll() != null && _repository.GetAll().Count() > 0)
            {
                var isDuplicate = GetSpecialityByName(speciality.Name) != null;
                if (isDuplicate)
                    throw new Exception("Speciality with the same name already exists");
            }
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
            throw new NoItemsInCollectionException("Speciality");
        }
        
        public Speciality? GetSpecialityById(int id)
        {
            var result = _repository.Get(id);
            if(result != null)
                return result;
            throw new ItemNotFoundException(id);
        }
        

        public int? GetSpecialityByName(string name)
        {
            var specialities = _repository.GetAll();
            if (specialities == null)
                throw new NoItemsInCollectionException("Speciality");
            var speciality = specialities.FirstOrDefault(s => s.Name == name);
            if (speciality != null)
                return speciality.Id;
            throw new ItemNotFoundException();
        }
    }
}
