using Npgsql;
using Ozon.MerchApi.Domain.AggregationModels.ItemPackAggregate;
using Ozon.MerchApi.Domain.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace Ozon.MerchApi.Domain.Infrastructure.Repositories.Implementation
{
    public class ItemPackRepository : IItemPackRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;

        public ItemPackRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }
    }
}