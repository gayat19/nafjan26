using FirstAPI.Models.DTOs;

namespace FirstAPI.Interfaces
{
    public interface IUserService
    {
     
            public Task<CheckUserResponseDto> CheckUser(CheckUserRequestDto request);
    }
}
