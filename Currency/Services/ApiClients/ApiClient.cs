namespace CurrencyApi.Services.ApiClients
{
    public interface ApiClient
    {
        public Task<T> GetDataAsync<T>(string endpoint);

        public Task<T> GetDataAsync<T>(string endpoint, int id);
    }
}
