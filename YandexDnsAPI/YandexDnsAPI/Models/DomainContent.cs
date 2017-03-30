using YandexDnsAPI.Enums;

namespace YandexDnsAPI.Models
{
    public class DomainContent
    {
        /// <summary>
        /// Domain name
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Type of DNS record
        /// </summary>
        public DnsSource.DnsTypeEnum Type { get; set; }

        /// <summary>
        /// Content of DNS record
        /// </summary>
        /// <example>
        /// A: IPv4
        /// AAAA: IPv6
        /// CNAME, MX, NS - FQDN (Fully Qualified Domain Name)
        /// TXT - text of TXT record, f.e. v=spf1 redirect=_spf.yandex.ru
        /// </example>
        public string Content { get; set; }

        /// <summary>
        /// Priority of DNS record. Less number - higher proprity.
        /// Default is 10.
        /// Required only for SRV or MX.
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Lifetime of DNS record in seconds.
        /// Defauls value is 21600.
        /// </summary>
        public int? TTL { get; set; }

        /// <summary>
        /// SubDomain name.
        /// Default value is '@'.
        /// Required if need to change/create record for subdomain  instead of domain
        /// </summary>
        public string SubDomain { get; set; }
    }
}
