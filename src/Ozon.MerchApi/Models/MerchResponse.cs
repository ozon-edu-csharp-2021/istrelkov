namespace Ozon.MerchApi.Models
{
    public class MerchResponse
    {
        public MerchResponse(int employeerId, bool isIssued)
        {
            EmployeerId = employeerId;
            IsIssued = isIssued;
        }

        public int EmployeerId { get;  }
        public bool IsIssued { get;  }
        
    }
}