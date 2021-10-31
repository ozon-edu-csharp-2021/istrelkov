namespace Ozon.MerchApi.Models
{
    public class CheckWasIssuedMerchResponse
    {
        public long EmployeeId { get; set; }
        public bool WasIssued { get; set; }

        public CheckWasIssuedMerchResponse(long employeeId)
        {
            EmployeeId = employeeId;
            WasIssued = true;
        }
    }
}