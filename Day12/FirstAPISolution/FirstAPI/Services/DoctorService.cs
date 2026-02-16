using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;

namespace FirstAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _doctorRepository;

        public DoctorService(IRepository<int,Doctor> doctorRepository) 
        {
            _doctorRepository = doctorRepository;
        }
        public CreateDoctorResponseDto CreateDoctor(CreateDoctorRequestDTO request)
        {
            Doctor doctor = new Doctor
            {
                Name = request.Name,
                Experience = request.Experience
            };
            var createdDoctor = _doctorRepository.Add(doctor);
            if (createdDoctor == null)
            {
                throw new UnableToCreateEntityException("Doctor");
            }
            return new CreateDoctorResponseDto
            {
                DoctorId = createdDoctor.Id
            };
        }

        public GetDoctorsResponseDto GetDoctors(GetDoctorRequestDto request)
        {
            var doctors = _doctorRepository.GetAll();
            if(doctors == null)
            {
                throw new EntityNotFoundException("Doctor");
            }

            var paginatedDoctors = doctors.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            return new GetDoctorsResponseDto
            {
                Doctors = paginatedDoctors,
                PageNumber = request.PageNumber,
                NumberOfRecords = paginatedDoctors.Count
            };
        }
    }
}
