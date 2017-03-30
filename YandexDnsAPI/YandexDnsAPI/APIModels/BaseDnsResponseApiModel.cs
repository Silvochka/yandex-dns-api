namespace YandexDnsAPI.APIModels.Response
{
    internal class BaseDnsResponseApiModel
    {
        public string domain { get; set; }
        public string success { get; set; }
        public string error { get; set; }
    }
}
