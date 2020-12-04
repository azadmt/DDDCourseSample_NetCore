namespace CustomerManagement.QueryService.Contract
{
    public class CustomerQueryDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public bool IsApprove { get; set; }
    }
}
