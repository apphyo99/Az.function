namespace Az.Services.Interfaces
{
    public interface ICosmosService
    {
        Task RunAsync(Func<string, Task> writeOutputAync);

        string GetEndpoint();
    }
}