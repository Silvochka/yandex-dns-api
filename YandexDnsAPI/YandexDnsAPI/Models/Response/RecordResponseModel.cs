using System;
using YandexDnsAPI.APIModels;
using YandexDnsAPI.Enums;
using YandexDnsAPI.Helpers;

namespace YandexDnsAPI.Models.Response
{
    public class RecordResponseModel : DomainContent
    {
        public int RecordId { get; set; }

        public string Fqdn { get; set; }

        internal static RecordResponseModel FromApiModel(Record record)
        {
            ValidationHelper.ThrowIfNull(record);

            return new RecordResponseModel()
            {
                RecordId = record.record_id,
                Type = (DnsSource.DnsTypeEnum)Enum.Parse(typeof(DnsSource.DnsTypeEnum), record.type),
                Domain = record.domain,
                Fqdn = record.fqdn,
                TTL = record.ttl,
                SubDomain = record.subdomain,
                Content = record.content,
                Priority = record.priority
            };
        }
    }
}
