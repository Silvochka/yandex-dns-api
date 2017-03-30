using System;
using YandexDnsAPI.APIModels;
using YandexDnsAPI.Enums;
using YandexDnsAPI.Helpers;

namespace YandexDnsAPI.Models.Response
{
    public class RecordResponseModel : DomainContent
    {
        /// <summary>
        /// DNS record identificator
        /// </summary>
        public int RecordId { get; set; }

        /// <summary>
        /// Full Qualified Domain Name
        /// </summary>
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
