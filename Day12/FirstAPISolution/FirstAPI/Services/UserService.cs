using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;

namespace FirstAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;

        public UserService(IRepository<string,User> userRepository,
                            IPasswordService passwordService,
                            ITokenService tokenService) 
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public async Task<CheckUserResponseDto> CheckUser(CheckUserRequestDto request)
        {
            var user = await _userRepository.Get(request.Username);
            if (user == null)
                throw new UnAuthorizedException("Invalid username");
            var userPasswordHash = _passwordService.HashPassword(request.Password, user.PasswordHash, out byte[] newhash);
            for (int i = 0; i < userPasswordHash.Length; i++)
            {
                if (userPasswordHash[i] != user.Password[i])
                    throw new UnAuthorizedException("Invalid password");
            }
            var tokenpaload = new TokenPayloadDto
            {
                Username = user.Username,
                Role = user.Role
            };
            var token = _tokenService.CreateToken(tokenpaload);
            return new CheckUserResponseDto
            {
                Token = token
            };
        }
    }
}
