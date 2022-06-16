using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppEscritorio.Tools
{
    internal class Api
    {
        public static async Task<TValue?> Get<TValue>(string url)
        {
            HttpClient client = new();

            HttpResponseMessage response = await client.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();
            var obj = JsonSerializer.Deserialize<TValue>(json);

            return obj;
        }

        public static async Task<TResponse?> Post<TValue, TResponse>(string url, TValue obj)
        {
            var json = JsonSerializer.Serialize(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new();

            var response = await client.PostAsync(url, data);

            var resultJson = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<TResponse>(resultJson);

            return result;
        }
    }
}
