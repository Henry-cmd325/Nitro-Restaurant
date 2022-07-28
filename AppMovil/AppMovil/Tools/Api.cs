using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMovil.Tools
{
    public static class Api
    {
        public static async Task<TValue> Get<TValue>(string url)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();         

            var obj = JsonConvert.DeserializeObject<TValue>(json);

            return obj;
        }

        public static async Task<TResponse> Post<TValue, TResponse>(string url, TValue obj)
        {
            HttpClient client = new HttpClient();

            var json = JsonConvert.SerializeObject(obj);
            
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, contentJson);

            var responseText = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TResponse>(responseText);

            return result;
        }
    }
}
