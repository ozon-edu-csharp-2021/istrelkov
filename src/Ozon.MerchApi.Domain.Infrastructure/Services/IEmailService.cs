using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.Infrastructure.Services
{
    public interface IEmailService
    {
        Task<bool> SendMail(long employeeId, CancellationToken cancellationToken);
    }
}