using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YandexDnsAPI.APIModels;

namespace YandexDnsAPI.Helpers
{
    internal static class HttpHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<T> RequestPostAsync<T>(string endpoint, string token, Dictionary<string, string> requestParameters)
        {
            var content = new FormUrlEncodedContent(requestParameters);

            if (client.DefaultRequestHeaders.Contains(ApiHeaders.Token))
            {
                client.DefaultRequestHeaders.Remove(ApiHeaders.Token);
            }

            client.DefaultRequestHeaders.Add(ApiHeaders.Token, token);

            var response = await client.PostAsync(endpoint, content);
            var responseString = await response.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
        }

        public static async Task<T> RequestGetAsync<T>(string endpoint, string token)
        {
            if (client.DefaultRequestHeaders.Contains(ApiHeaders.Token))
            {
                client.DefaultRequestHeaders.Remove(ApiHeaders.Token);
            }

            client.DefaultRequestHeaders.Add(ApiHeaders.Token, token);

            var response = await client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
