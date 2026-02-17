namespace FirstAPI.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public byte[] Password { get; set; } = Array.Empty<byte>();
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public string Role { get; set; } = string.Empty;
        public Doctor? Doctor { get; set; }
    }
}
