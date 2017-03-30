namespace YandexDnsAPI.APIModels.Response
{
    internal class GetDnsResponseApiModel : BaseDnsResponseApiModel
    {
        public Record[] records { get; set; }
    }
}
