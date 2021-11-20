using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public Task<bool> SendMail(long employeeId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}