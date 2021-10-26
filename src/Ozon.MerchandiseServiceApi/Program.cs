using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Ozon.MerchandiseServiceApi;
using Ozon.MerchandiseServiceApi.Infrastructure.Extensions;


CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
        .AddInfrastructure();