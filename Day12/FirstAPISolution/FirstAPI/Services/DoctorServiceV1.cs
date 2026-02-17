using FirstAPI.Contexts;
using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Services
{
    public class DoctorServiceV1 : IDoctorService
    {
        private readonly ClinicContext _context;
        private readonly IPasswordService _passwordService;

        public DoctorServiceV1(ClinicContext context, IPasswordService passwordService) 
        {
            _context = context;
            _passwordService = passwordService;
        }
        public CreateDoctorResponseDto CreateDoctor(CreateDoctorRequestDTO request)
        {
            //Tranaction for creating doctor and user
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var encryptedPassword = _passwordService.HashPassword(request.Password, null, out byte[] hashKey);
                var user = new Models.User
                {
                    Username = request.Username,
                    Password = encryptedPassword,
                    PasswordHash = hashKey,
                    Role = "Doctor",
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                var doctor = new Models.Doctor
                {
                    Name = request.Name,
                    Experience = request.Experience,
                    Username = request.Username
                };
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                transaction.Commit();
                return new CreateDoctorResponseDto
                {
                    DoctorId = doctor.Id
                };
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        public GetDoctorsResponseDto GetDoctors(GetDoctorRequestDto request)
        {
            //execute stored procedure to get doctors with pagination
            var doctors = _context.Doctors.FromSqlRaw("EXEC proc_GetAllDoctors {0}, {1}", ((request.PageNumber-1)*request.PageSize), request.PageSize).ToList();
            if(doctors == null || doctors.Count == 0)
            {
                throw new EntityNotFoundException("Doctor");
            }
            return new GetDoctorsResponseDto
            {
                Doctors = doctors,
                PageNumber = request.PageNumber,
                NumberOfRecords = doctors.Count
            };
            
        }
    }
}
