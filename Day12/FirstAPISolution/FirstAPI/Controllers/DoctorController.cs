using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using FirstAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("GetDoctors")]
        public ActionResult GetDoctors(GetDoctorRequestDto requestDto)
        {
            try
            {
                var response = _doctorService.GetDoctors(requestDto);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateDoctor(CreateDoctorRequestDTO doctor)
        {
            try
            {
                var result = _doctorService.CreateDoctor(doctor);
                return Created($"https://baseurl/doctors/{result.DoctorId}", result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
