using Dapper;

using Npgsql;

using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;
using Ozon.MerchApi.Domain.AggregationModels.SkuPackAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ozon.MerchApi.Domain.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace Ozon.MerchApi.Domain.Infrastructure.Repositories.Implementation
{
    public class SkuPackRepository : ISkuPackRepository
    {
        private const int TIMEOUT = 5;
        private readonly IChangeTracker _changeTracker;
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;

        public SkuPackRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }

        public async Task<List<SkuPack>> CreateAsync(MerchOrder merchOrder, CancellationToken cancellationToken)
        {
            const string sql = @"
                INSERT INTO SkuPack (
                    MerchOrder_id
                    ,Sku_id
                    ,Quantity
                )
                OUTPUT INSERTED.Id
                VALUES (
                    @MerchOrder_id
                    @Sku_id
                    @Quantity
                );";

            foreach (SkuPack skuPack in merchOrder.SkuPackCollection)
            {
                var parameters = new
                {
                    MerchOrderId = merchOrder.Id,
                    SkuId = skuPack.Sku.Value,
                    Quantity = skuPack.Quantity.Value,
                };

                CommandDefinition commandDefinition = new(
                    sql,
                    parameters: parameters,
                    commandTimeout: TIMEOUT,
                    cancellationToken: cancellationToken);

                NpgsqlConnection connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
                long id = await connection.QuerySingleAsync<long>(commandDefinition);
                skuPack.SetId(id);

                _changeTracker.Track(skuPack);
            }

            return merchOrder.SkuPackCollection.ToList();
        }
    }
}