using Dapper;

using Npgsql;

using Ozon.MerchApi.Domain.AggregationModels.Enumerations;
using Ozon.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using Ozon.MerchApi.Domain.Infrastructure.Repositories.Extension;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ozon.MerchApi.Domain.Infrastructure.Repositories.Helpers;
using Ozon.MerchApi.Domain.Infrastructure.Repositories.Infrastructure.Interfaces;
using static Dapper.SqlMapper;

namespace Ozon.MerchApi.Domain.Infrastructure.Repositories.Implementation
{
    public class MerchPackRepository : IMerchPackRepository
    {
        private const int TIMEOUT = 5;
        private readonly IChangeTracker _changeTracker;
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;

        public MerchPackRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }

        public async Task<MerchPack> FindByTypeAsync(MerchPackType merchPackType, CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT
                    MerchPack.Id
                    ,MerchPack.MerchPackType_id

                FROM MerchPack
                JOIN MerchPackType ON MerchPackType.Id = MerchPack.MerchPackType_id
                WHERE MerchPackType.Id = @MerchPackTypeId

                SELECT
                    ItemPack.Id
                    ,ItemPack.MerchPack_id
                    ,ItemPack.StockItem_id
                    ,ItemPack.Quantity

                FROM ItemPack
                WHERE ItemPack.MerchPack_id IN (
                        SELECT Id
                        FROM MerchPack
                        WHERE MerchPackType_id = @MerchPackTypeId);";

            var parameters = new
            {
                MerchPackTypeId = merchPackType.Id,
            };

            NpgsqlConnection connection = await _dbConnectionFactory.CreateConnection(cancellationToken);

            CommandDefinition commandDefinition = new(
                sql,
                parameters: parameters,
                commandTimeout: TIMEOUT,
                cancellationToken: cancellationToken);

            GridReader reader = await connection.QueryMultipleAsync(commandDefinition);

            Models.MerchPack merchPackModel = reader
                .Map<Models.MerchPack, Models.ItemPack, long>
                (
                    merchPack => merchPack.Id,
                    itemPack => itemPack.MerchPackId,
                    (merchPack, itemPacks) => merchPack.ItemPackCollection = itemPacks
                ).FirstOrDefault();

            MerchPack merchPack = ModelsMapper.MerchPackModelToEntity(merchPackModel);

            if (merchPack is not null)
            {
                _changeTracker.Track(merchPack);
            }

            return merchPack;
        }
    }
}