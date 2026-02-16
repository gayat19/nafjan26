using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IDoctorService
    {
        public CreateDoctorResponseDto CreateDoctor(CreateDoctorRequestDTO request);
        public GetDoctorsResponseDto GetDoctors(GetDoctorRequestDto request);

    }
}
