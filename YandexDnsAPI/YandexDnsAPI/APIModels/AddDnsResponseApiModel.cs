namespace YandexDnsAPI.APIModels.Response
{
    internal class AddDnsResponseApiModel
    {
        public string domain { get; set; }
        public Record record { get; set; }
        public string success { get; set; }
        public string error { get; set; }
    }
}
