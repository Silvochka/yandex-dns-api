using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YandexDnsAPI.APIModels;
using YandexDnsAPI.APIModels.Response;
using YandexDnsAPI.Enums;
using YandexDnsAPI.Models.Request;
using YandexDnsAPI.Models.Response;

namespace YandexDnsAPI.Services
{
    public static class YandexDnsApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string AddDnsEndpoint = "https://pddimp.yandex.ru/api2/admin/dns/add";

        public static async Task<RecordResponseModel> AddDnsRecord(AddDnsRequestModel request)
        {
            request.Validate();

            var parameters = new Dictionary<string, string>();
            parameters.Add(ApiParameters.Domain, request.DomainContent.Domain);
            parameters.Add(ApiParameters.Content, request.DomainContent.Content);
            parameters.Add(ApiParameters.Type, DnsSource.DnsTypes[request.DomainContent.Type]);

            AddIfNotEmpty(request.AdminEmail, ApiParameters.AdminEmail, parameters);
            AddIfNotEmpty(request.Port, ApiParameters.Port, parameters);
            AddIfNotEmpty(request.Target, ApiParameters.Target, parameters);
            AddIfNotEmpty(request.DomainContent.SubDomain, ApiParameters.SubDomain, parameters);

            AddIfNotNull(request.DomainContent.Priority, ApiParameters.Priority, parameters);
            AddIfNotNull(request.Weight, ApiParameters.Weight, parameters);
            AddIfNotNull(request.DomainContent.TTL, ApiParameters.TTL, parameters);

            var response = await RequestPostAsync<AddDnsResponseApiModel>(AddDnsEndpoint, request.Token, parameters);

            if (response.success == SuccessStates.Ok)
            {
                return RecordResponseModel.FromApiModel(response);
            }
            else
            {
                throw new ApplicationException(response.error);
            }
        }

        private static void AddIfNotEmpty(string value, string key, Dictionary<string, string> parameters)
        {
            if (!string.IsNullOrEmpty(value))
            {
                parameters.Add(key, value);
            }
        }

        private static void AddIfNotNull(int? value, string key, Dictionary<string, string> parameters)
        {
            if (value.HasValue)
            {
                parameters.Add(key, value.Value.ToString());
            }
        }

        private static async Task<T> RequestPostAsync<T>(string endpoint, string token, Dictionary<string, string> requestParameters)
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
    }
}
