namespace YandexDnsAPI.APIModels
{
    internal class Record
    {
        public int record_id { get; set; }
        public string type { get; set; }
        public string domain { get; set; }
        public string subdomain { get; set; }
        public string fqdn { get; set; }
        public string content { get; set; }
        public int ttl { get; set; }
        public int priority { get; set; }
    }
}
