
using Newtonsoft.Json;
using System.Text;

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

        public async Task<T> GetDataAsync<T>(string endpoint, string[] parametres)
        {
            var builder = new StringBuilder($"https://api.nbrb.by/exrates/{endpoint}?");
            foreach (var param in parametres)
            {
                builder.Append(param);
                builder.Append("&");
            }

            var url = builder.Remove(builder.Length - 1, 1).ToString();
            var responce = await _httpClient.GetAsync(url);
            responce.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<T>(await responce.Content.ReadAsStringAsync());
        }


        public async Task<T> GetDataAsync<T>(string endpoint, string id, string[] parametres)
        {
            var builder = new StringBuilder($"https://api.nbrb.by/exrates/{endpoint}/{id}?");
            foreach(var param in parametres)
            {
                builder.Append(param);
                builder.Append("&");
            }

            var url = builder.Remove(builder.Length - 1, 1).ToString();
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

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
