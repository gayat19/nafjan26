namespace FirstAPI.Models.DTOs
{
    public class GetDoctorsResponseDto
    {
        public List<Doctor>? Doctors { get; set; }
        public int PageNumber { get; set; }
        public int NumberOfRecords { get; set; }
    }
}
