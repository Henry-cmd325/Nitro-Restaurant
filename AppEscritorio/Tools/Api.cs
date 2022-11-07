using AppEscritorio.Models.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
            var obj = JsonSerializer.Deserialize<TValue>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return obj;
        }

        public static async Task<TResponse> Post<TValue, TResponse>(string url, TValue obj)
        {
            HttpClient client = new();

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
            HttpClient client = new();

            var response = await client.PutAsJsonAsync(url, obj);

            return response.IsSuccessStatusCode;
        }


    }
}
