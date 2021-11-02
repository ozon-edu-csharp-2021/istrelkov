namespace Ozon.MerchApi.Models
{
    public class IssueMerchResponse
    {
        public long EmployeeId { get; }

        public IssueMerchResponse(long employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}