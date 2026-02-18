using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<CreateDoctorResponseDto> CreateDoctor(CreateDoctorRequestDTO request);
        public Task<GetDoctorsResponseDto> GetDoctors(GetDoctorRequestDto request);

    }
}
