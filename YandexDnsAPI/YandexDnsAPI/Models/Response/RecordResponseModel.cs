using System;
using YandexDnsAPI.APIModels.Response;
using YandexDnsAPI.Enums;
using YandexDnsAPI.Helpers;

namespace YandexDnsAPI.Models.Response
{
    public class RecordResponseModel : DomainContent
    {
        public int RecordId { get; set; }

        public string Fqdn { get; set; }

        internal static RecordResponseModel FromApiModel(AddDnsResponseApiModel apiModel)
        {
            ValidationHelper.ThrowIfNull(apiModel);
            ValidationHelper.ThrowIfNull(apiModel.record);

            return new RecordResponseModel()
            {
                RecordId = apiModel.record.record_id,
                Type = (DnsSource.DnsTypeEnum)Enum.Parse(typeof(DnsSource.DnsTypeEnum), apiModel.record.type),
                Domain = apiModel.record.domain,
                Fqdn = apiModel.record.fqdn,
                TTL = apiModel.record.ttl,
                SubDomain = apiModel.record.subdomain,
                Content = apiModel.record.content,
                Priority = apiModel.record.priority
            };
        }
    }
}
