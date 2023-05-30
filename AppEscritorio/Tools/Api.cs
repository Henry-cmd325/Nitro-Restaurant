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
        public static string Token = string.Empty;
        private static readonly HttpClient _client;

        static Api()
        {
            _client = new HttpClient();
        }
        public static async Task<TValue?> Get<TValue>(string url)
        {
           if (Token != string.Empty)
            {
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            }

            HttpResponseMessage response = await _client.GetAsync(url);

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
				_client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
			};

            var response = await _client.PostAsJsonAsync(url, obj);

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
				_client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
			}

			var response = await _client.PutAsJsonAsync(url, obj);

            return response.IsSuccessStatusCode;
        }


    }
}
