using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppEscritorio.Tools
{
    public class Api
    {
        public static string Token = string.Empty;
        private static readonly HttpClient client;

        static Api()
        {
            client = new HttpClient();
        }
        public static async Task<TValue?> Get<TValue>(string url)
        {
            if (Token != string.Empty)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            HttpResponseMessage response = await client.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();
            var obj = JsonSerializer.Deserialize<TValue>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return obj;
        }

        public static async Task<TResponse> Post<TValue, TResponse>(string url, TValue obj)
        {
            if (Token != string.Empty)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            var response = await client.PostAsJsonAsync(url, obj);

            var resultJson = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<TResponse>(resultJson, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }

        public static async Task<bool> Put<TValue>(string url, TValue obj)
        {
            if (Token != string.Empty)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            var response = await client.PutAsJsonAsync(url, obj);

            return response.IsSuccessStatusCode;
        }


    }
}
