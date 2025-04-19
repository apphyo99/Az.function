namespace Az.Models.Settings
{
    public record Configuration
    {
        public required AzureCosmosDB AzureCosmosDB { get; init; }
        public required AzureAD AzureAD { get; init; }
    }

    public record AzureCosmosDB
    {
        public required string AccountEndpoint { get; init; }

        public required string DatabaseName { get; init; }

        public required string ContainerName { get; init; }

        public required string ConnectionString { get; init; }
    }

    public record AzureAD
    {
        public required string ClientId { get; init; }

        public required string ClientSecret { get; init; }

        public required string TenantId { get; init; }
    }
}