using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Az.Models.Settings;
using Az.Services.Cosmos;
using Microsoft.Azure.Cosmos;
using Az.Services.Interfaces;

var builder = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
        config.AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddOptions<Configuration>().Bind(context.Configuration.GetSection(nameof(Configuration)));
        services.AddSingleton<IConfiguration>(context.Configuration);

        services.AddSingleton<ICosmosService>((ServiceProvider) =>
        {
            var configuration = ServiceProvider.GetRequiredService<IConfiguration>();
            var options = ServiceProvider.GetRequiredService<IOptions<Configuration>>();
            return new CosmosService(new CosmosClient(options.Value.AzureCosmosDB.ConnectionString), options);
        });
    });


var host = builder.Build();

host.Run();
