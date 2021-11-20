using Ozon.MerchApi.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.Contracts
{
    public interface IRepository<TAggregationRoot> where TAggregationRoot : IAggregationRoot
    { 
    }

}