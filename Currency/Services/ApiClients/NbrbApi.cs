
using Newtonsoft.Json;

namespace CurrencyApi.Services.ApiClients
{
    public class NbrbApi: ApiClient
    {
        private readonly HttpClient _httpClient;
        public NbrbApi()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetDataAsync<T>(string endpoint)
        {
            var url = $"https://api.nbrb.by/exrates/{endpoint}";
            var responce = await _httpClient.GetAsync(url);
            responce.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<T>(await responce.Content.ReadAsStringAsync());
        }

        public async Task<T> GetDataAsync<T>(string endpoint, int id)
        {
            var url = $"https://api.nbrb.by/exrates/{endpoint}/{id}";
            var responce = await _httpClient.GetAsync(url);
            responce.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<T>(await responce.Content.ReadAsStringAsync());
        }
    }
}
