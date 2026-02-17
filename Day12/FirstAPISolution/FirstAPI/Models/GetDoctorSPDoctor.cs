namespace FirstAPI.Models
{
    public class GetDoctorSPDoctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Experience { get; set; }
        public string? Username { get; set; }
    }
}
