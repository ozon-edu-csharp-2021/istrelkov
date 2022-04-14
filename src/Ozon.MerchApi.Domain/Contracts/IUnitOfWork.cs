using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ValueTask StartTransaction(CancellationToken token);

        Task SaveChanges(CancellationToken token);
    }
}