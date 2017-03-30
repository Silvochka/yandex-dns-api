using YandexDnsAPI.Enums;
using YandexDnsAPI.Helpers;

namespace YandexDnsAPI.Models.Request
{
    public class EditDnsRequestModel
    {
        /// <summary>
        /// Yandex token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// DNS record identificator
        /// </summary>
        public int RecordId { get; set; }

        /// <summary>
        /// Email address of domain administrator.
        /// Requred only for SOA
        /// </summary>
        public string AdminEmail { get; set; }

        /// <summary>
        /// Domain properties
        /// </summary>
        public DomainContent DomainContent { get; set; }

        /// <summary>
        /// Weight of SRV record relatively of other SRV records with same priority.
        /// Required only for SRV
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// TCP or UDP port of host.
        /// Required only for SRC record
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Canonical host name.
        /// Required onl for SRV record
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Frequency of checking the secondary DNS servers for a DNS record for this zone.
        /// Allowed values between 900 and 86400. 
        /// Recommented value is 10800.
        /// Required for SOA record.
        /// </summary>
        public int? Refresh { get; set; }

        /// <summary>
        /// Time in seconds between secondary DNS servers attempts to retrieve zone records. 
        /// Retries would be sent if the primary server doesn't respond.
        /// Allowed values between 90 and 3600.
        /// Recommended value is 900.
        /// Required for SOA record.
        /// </summary>
        public int? Retry { get; set; }

        /// <summary>
        /// Time in seconds after which secondary DNS servers consider the zone records not-existent if primary server doesn't respond.
        /// Allowed values between 90 and 3600.
        /// Recommended value is 900.
        /// Required for SOA record.
        /// </summary>
        public int? Expire { get; set; }

        /// <summary>
        /// Time in seconds during which the negative response (ERROR = NXDOMAIN) from DNS server will be cached.
        /// Allowed values between 90 and 86400.
        /// Recommended value is 10800.
        /// Required for SOA record.
        /// </summary>
        public int? NegCache { get; set; }

        public void Validate()
        {
            ValidationHelper.ThrowIfNullOrEmpty(this.Token);
            ValidationHelper.ThrowIfNull(this.DomainContent);
            ValidationHelper.ThrowIfNullOrEmpty(this.DomainContent.Domain);
            ValidationHelper.ThrowIfNotInBound(this.DomainContent.TTL, 900, 1209600);
            ValidationHelper.ThrowIfNotInBound(this.Refresh, 900, 86400);
            ValidationHelper.ThrowIfNotInBound(this.Retry, 90, 3600);
            ValidationHelper.ThrowIfNotInBound(this.Expire, 90, 3600);
            ValidationHelper.ThrowIfNotInBound(this.NegCache, 90, 86400);


            ValidationHelper.ThrowIfFalse(!DnsSource.DnsTypes.ContainsKey(this.DomainContent.Type), nameof(this.DomainContent.Type));

            if (this.DomainContent.Type == DnsSource.DnsTypeEnum.SOA)
            {
                ValidationHelper.ThrowIfNull(this.Refresh);
                ValidationHelper.ThrowIfNull(this.Retry);
                ValidationHelper.ThrowIfNull(this.Expire);
                ValidationHelper.ThrowIfNull(this.NegCache);
                ValidationHelper.ThrowIfNullOrEmpty(this.AdminEmail);
            }

            if (this.DomainContent.Type == DnsSource.DnsTypeEnum.SRV)
            {
                ValidationHelper.ThrowIfNull(this.DomainContent.Priority);
                ValidationHelper.ThrowIfNull(this.Weight);
                ValidationHelper.ThrowIfNullOrEmpty(this.Port);
                ValidationHelper.ThrowIfNullOrEmpty(this.Target);
            }

            if (this.DomainContent.Type == DnsSource.DnsTypeEnum.MX)
            {
                ValidationHelper.ThrowIfNull(this.DomainContent.Priority);
            }
        }
    }
}
