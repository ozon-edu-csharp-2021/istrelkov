using Dapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Ozon.MerchApi.Domain.AggregationModels.ItemPackAggregate;
using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;
using Ozon.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using Ozon.MerchApi.Domain.AggregationModels.SkuPackAggregate;
using Ozon.MerchApi.Domain.Contracts;
using Ozon.MerchApi.Domain.Infrastructure.Configuration;
using Ozon.MerchApi.Domain.Infrastructure.Extensions;
using Ozon.MerchApi.Domain.Infrastructure.Repositories.Implementation;
using Ozon.MerchApi.Domain.Infrastructure.Repositories.Infrastructure;
using Ozon.MerchApi.Domain.Infrastructure.Repositories.Infrastructure.Interfaces;
using Ozon.MerchApi.Domain.Infrastructure.Services;
using Ozon.MerchApi.GrpcServices;
using Ozon.MerchApi.Infrastructure.Interceptors;
using Ozon.MerchApi.Services;
using Ozon.MerchApi.Services.Interfaces;

namespace Ozon.MerchApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchApiGrpsService>();
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AddMediator(services);
            AddDatabaseComponents(services);
            AddRepositories(services);

            services.AddSingleton<IMerchandiseService, MerchandiseService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IStockApiService, StockApiService>();
            services.AddInfrastructureServices();
            services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
        }

        static private void AddMediator(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup), typeof(DatabaseConnectionOptions));
        }

        static private void AddRepositories(IServiceCollection services)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;    
            services.AddScoped<IMerchOrderRepository, MerchOrderRepository>();
            services.AddScoped<IMerchPackRepository, MerchPackRepository>();
            services.AddScoped<ISkuPackRepository, SkuPackRepository>();
        }

        private void AddDatabaseComponents(IServiceCollection services)
        {
            services.Configure<DatabaseConnectionOptions>(Configuration.GetSection(nameof(DatabaseConnectionOptions)));
            services.AddScoped<IDbConnectionFactory<NpgsqlConnection>, NpgsqlConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChangeTracker, ChangeTracker>();
        }

    }
}