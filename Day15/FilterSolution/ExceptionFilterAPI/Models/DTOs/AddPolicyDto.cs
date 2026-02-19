namespace ExceptionFilterAPI.Models.DTOs
{
    public class AddPolicyDto
    {
        public int InsuranceNumber { get; set; }
        public int? CustomerId { get; set; }
        public AddCustomerDto? MyProperty { get; set; }
    }
}
