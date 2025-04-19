using Az.Services.Interfaces;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Settings = Az.Models.Settings;

namespace Az.Services.Graph;

public sealed class GraphService(
    IOptions<Settings.Configuration> configurationOptions,
    ILogger<GraphService> logger

) : IGraphService
{
    private readonly Settings.Configuration _config = configurationOptions.Value;

    private readonly Settings.Configuration configuration = configurationOptions.Value;
    private readonly ILogger<GraphService> _logger = logger;

    public async Task RunAsync()
    {
        string _clientId = _config.AzureAD.ClientId;
        string _tenantId = _config.AzureAD.TenantId;
        var options = new DeviceCodeCredentialOptions
        {

            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            ClientId = _clientId,
            TenantId = _tenantId,
            DeviceCodeCallback = async (deviceCodeResult, cancellationToken) =>
            {
                _logger.LogInformation($"Please open the following URL and enter the code: {deviceCodeResult.VerificationUri}");
                _logger.LogInformation($"Code: {deviceCodeResult.UserCode}");

                await Task.CompletedTask;
            }
        };

        var deviceCodeCredential = new DeviceCodeCredential(options);

        var graphClient = new GraphServiceClient(deviceCodeCredential, new[] { "User.Read" });

        var user = await graphClient.Me.GetAsync();

        _logger.LogInformation($"User: {user.DisplayName}");

    }

}