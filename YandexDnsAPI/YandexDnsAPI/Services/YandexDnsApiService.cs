using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YandexDnsAPI.APIModels;
using YandexDnsAPI.APIModels.Response;
using YandexDnsAPI.Enums;
using YandexDnsAPI.Helpers;
using YandexDnsAPI.Models.Request;
using YandexDnsAPI.Models.Response;

namespace YandexDnsAPI.Services
{
    public static class YandexDnsApiService
    {
        private static readonly string AddDnsEndpoint = "https://pddimp.yandex.ru/api2/admin/dns/add";
        private static readonly string GetDnsEndpoint = "https://pddimp.yandex.ru/api2/admin/dns/list?domain=";
        private static readonly string EditDnsEndpoint = "https://pddimp.yandex.ru/api2/admin/dns/edit";

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

            var response = await HttpHelper.RequestPostAsync<AddDnsResponseApiModel>(AddDnsEndpoint, request.Token, parameters);

            if (response.success == SuccessStates.Ok)
            {
                ValidationHelper.ThrowIfNull(response);
                return RecordResponseModel.FromApiModel(response.record);
            }
            else
            {
                throw new ApplicationException(response.error);
            }
        }

        public static async Task<IEnumerable<RecordResponseModel>> GetDnsRecord(GetDnsRequestModel request)
        {
            request.Validate();

            var uri = GetDnsEndpoint + request.Domain;
            var response = await HttpHelper.RequestGetAsync<GetDnsResponseApiModel>(uri, request.Token);

            if (response.success == SuccessStates.Ok)
            {
                return response.records.Select(x => RecordResponseModel.FromApiModel(x));
            }
            else
            {
                throw new ApplicationException(response.error);
            }
        }

        public static async Task<RecordResponseModel> EditDnsRecord(EditDnsRequestModel request)
        {
            request.Validate();

            var parameters = new Dictionary<string, string>();
            parameters.Add(ApiParameters.Domain, request.DomainContent.Domain);
            parameters.Add(ApiParameters.RecordId, request.RecordId.ToString());

            AddIfNotEmpty(request.DomainContent.SubDomain, ApiParameters.SubDomain, parameters);
            AddIfNotEmpty(request.DomainContent.Content, ApiParameters.Content, parameters);
            AddIfNotEmpty(request.AdminEmail, ApiParameters.AdminEmail, parameters);
            AddIfNotEmpty(request.Port, ApiParameters.Port, parameters);
            AddIfNotEmpty(request.Target, ApiParameters.Target, parameters);

            AddIfNotNull(request.DomainContent.TTL, ApiParameters.TTL, parameters);
            AddIfNotNull(request.Refresh, ApiParameters.Refresh, parameters);
            AddIfNotNull(request.Retry, ApiParameters.Retry, parameters);
            AddIfNotNull(request.Expire, ApiParameters.Expire, parameters);
            AddIfNotNull(request.NegCache, ApiParameters.NegCache, parameters);
            AddIfNotNull(request.DomainContent.Priority, ApiParameters.Priority, parameters);
            AddIfNotNull(request.Weight, ApiParameters.Weight, parameters);

            var response = await HttpHelper.RequestPostAsync<EditDnsResponseApiModel>(EditDnsEndpoint, request.Token, parameters);

            if (response.success == SuccessStates.Ok)
            {
                ValidationHelper.ThrowIfNull(response);
                return RecordResponseModel.FromApiModel(response.record);
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
    }
}
