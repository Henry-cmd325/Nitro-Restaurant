using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMovil.Tools
{
    public class Api
    {
        private readonly HttpClient _client;

        public Api()
        {
            _client = new HttpClient();
        }
        public async Task<TValue> Get<TValue>(string url)
        { 
            HttpResponseMessage response = await _client.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();         

            var obj = JsonConvert.DeserializeObject<TValue>(json);

            return obj;
        }

        public async Task<TResponse> Post<TValue, TResponse>(string url, TValue obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, contentJson);

            var responseText = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TResponse>(responseText);

            return result;
        }

        public async Task<bool> Delete(string url)
        {
            var response = await _client.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Put(string url, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(url, contentJson);

            return response.IsSuccessStatusCode;
        }
    }
}
