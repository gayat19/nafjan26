namespace FirstAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Experience { get; set; }
        public User? User { get; set; }
        public string? Username { get; set; }
    }
}
