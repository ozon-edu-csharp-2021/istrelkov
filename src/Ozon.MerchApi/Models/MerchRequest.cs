namespace Ozon.MerchApi.Models
{
    public class MerchRequest
    {
        public MerchRequest(int employeerId)
        {
            EmployeerId = employeerId;
        }

        public int EmployeerId { get; }
    }
}