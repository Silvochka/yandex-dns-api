using System.Collections.Generic;

namespace YandexDnsAPI.Enums
{
    public static class DnsSource
    {
        public enum DnsTypeEnum
        {
            SRV,
            TXT,
            NS,
            MX,
            SOA,
            A,
            AAAA,
            CNAME
        }

        public static Dictionary<DnsTypeEnum, string> DnsTypes = new Dictionary<DnsTypeEnum, string>
        {
            { DnsTypeEnum.SRV, "SRV"},
            { DnsTypeEnum.TXT, "TXT"},
            { DnsTypeEnum.NS, "NS"},
            { DnsTypeEnum.MX, "MX"},
            { DnsTypeEnum.SOA, "SOA"},
            { DnsTypeEnum.A ,"A"},
            { DnsTypeEnum.AAAA, "AAAA"},
            { DnsTypeEnum.CNAME, "CNAME"},
        };
    }
}
