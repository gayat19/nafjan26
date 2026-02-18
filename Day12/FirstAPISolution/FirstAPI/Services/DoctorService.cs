using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;

namespace FirstAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _doctorRepository;
        private readonly IPasswordService _passwordService;
        private readonly IRepository<string, User> _userRepository;

        public DoctorService(IRepository<int,Doctor> doctorRepository,
                             IRepository<string,User> userRepository,
                               IPasswordService passwordService) 
        {
            _doctorRepository = doctorRepository;
            _passwordService = passwordService;
            _userRepository = userRepository;
        }
        public async Task<CreateDoctorResponseDto> CreateDoctor(CreateDoctorRequestDTO request)
        {
            Doctor doctor = new Doctor
            {
                Name = request.Name,
                Experience = request.Experience
            };
            if ((await _userRepository.Get(request.Username)) != null)
            {
                throw new Exception($"Username {request.Username} already exixt");
            }
            byte[] hashKey;
            var encryptedPassword = _passwordService.HashPassword(request.Password,null,out hashKey);
            var user = new User
            {
                Username = request.Username,
                PasswordHash = hashKey,
                Password = encryptedPassword,
                Role = "Doctor",
            };
            var createdUser = await _userRepository.Add(user);
  
            if (createdUser == null)
            {
                throw new UnableToCreateEntityException("User");
            }
            var createdDoctor = await _doctorRepository.Add(doctor);
            if (createdDoctor == null)
            {
                throw new UnableToCreateEntityException("Doctor");
            }
            return new CreateDoctorResponseDto
            {
                DoctorId = createdDoctor.Id
            };
        }

        public async Task<GetDoctorsResponseDto> GetDoctors(GetDoctorRequestDto request)
        {
            var doctors = await _doctorRepository.GetAll();
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
