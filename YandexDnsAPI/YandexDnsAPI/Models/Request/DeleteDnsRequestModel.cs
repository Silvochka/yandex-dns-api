using YandexDnsAPI.Helpers;

namespace YandexDnsAPI.Models.Request
{
    public class DeleteDnsRequestModel
    {
        /// <summary>
        /// Yandex token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Domain name
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// DNS record identificator
        /// </summary>
        public int RecordId { get; set; }

        public void Validate()
        {
            ValidationHelper.ThrowIfNullOrEmpty(this.Token);
            ValidationHelper.ThrowIfNullOrEmpty(this.Domain);
        }
    }
}
