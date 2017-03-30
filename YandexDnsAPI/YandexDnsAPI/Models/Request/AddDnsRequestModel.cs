using YandexDnsAPI.Enums;
using YandexDnsAPI.Helpers;

namespace YandexDnsAPI.Models.Request
{
    public class AddDnsRequestModel
    {
        /// <summary>
        /// Yandex token
        /// </summary>
        public string Token { get; set; }

        public DomainContent DomainContent { get; set; }

        /// <summary>
        /// Email address of domain administrator.
        /// Requred only for SOA
        /// </summary>
        public string AdminEmail { get; set; }

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

        public void Validate()
        {
            ValidationHelper.ThrowIfNullOrEmpty(this.Token);
            ValidationHelper.ThrowIfNullOrEmpty(this.DomainContent.Domain);
            ValidationHelper.ThrowIfNullOrEmpty(this.DomainContent.Content);
            ValidationHelper.ThrowIfFalse(!DnsSource.DnsTypes.ContainsKey(this.DomainContent.Type), nameof(this.DomainContent.Type));

            if (this.DomainContent.Type == DnsSource.DnsTypeEnum.SOA)
            {
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
