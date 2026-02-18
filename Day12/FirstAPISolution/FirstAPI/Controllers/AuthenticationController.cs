using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Models.DTOs;
using FirstAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<CheckUserResponseDto>> Login(CheckUserRequestDto userRequestDto)
        {
            try
            {
                var result = await _userService.CheckUser(userRequestDto);
                return Ok(result);
            }
            catch (UnAuthorizedException ue)
            {
                 return Unauthorized("Invalid username or password");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
