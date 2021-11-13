using MediatR;

using Microsoft.Extensions.DependencyInjection;

using Ozon.MerchApi.Domain.Infrastructure.Handlers.MerchOrderAggregate;

namespace Ozon.MerchApi.Domain.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(
                typeof(CreateManualMerchOrderCommandHandler).Assembly,
                typeof(GetMerchOrdersQueryHandler).Assembly);

            return services;
        }

        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}