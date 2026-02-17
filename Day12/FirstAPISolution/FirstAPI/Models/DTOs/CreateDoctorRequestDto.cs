using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models.DTOs
{
    public class CreateDoctorRequestDTO
    {
        [Required(ErrorMessage ="Doctor name cannot be empty")]
        public string Name { get; set; } = string.Empty;
        public int Experience { get; set; }

        [Required(ErrorMessage = "Username name cannot be empty")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password name cannot be empty")]
        public string Password { get; set; } = string.Empty;

    }
}
