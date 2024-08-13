namespace CurrencyApi.Services.ApiClients
{
    /// <summary>
    /// Trait with base api actions
    /// </summary>
    public interface ApiClient
    {
        public Task<T> GetDataAsync<T>(string endpoint);

        public Task<T> GetDataAsync<T>(string endpoint, int id);
    }
}
