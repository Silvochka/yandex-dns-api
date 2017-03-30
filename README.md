# yandex-dns-api  [![Build status](https://ci.appveyor.com/api/projects/status/dj2lvre3av0pkfqw/branch/develop?svg=true)](https://ci.appveyor.com/project/Silvochka/yandex-dns-api/branch/develop)
C# wrapper for [Yandex DNS API](https://tech.yandex.ru/pdd/doc/concepts/api-dns-docpage/)

Using this library, you can call Yandex API:

- [Add](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Services/YandexDnsApiService.cs#L21) DNS record
  - [Request Model](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Models/Request/AddDnsRequestModel.cs)
  - Response is [DNS record](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Models/Response/RecordResponseModel.cs)
- [Edit](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Services/YandexDnsApiService.cs#L70) DNS record
  - [Request Model](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Models/Request/EditDnsRequestModel.cs)
  - Response is [DNS record](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Models/Response/RecordResponseModel.cs)
- [Get](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Services/YandexDnsApiService.cs#L52) DNS records for given domain
  - [Request Model](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Models/Request/GetDnsRequestModel.cs)
  - Response is array of [DNS records](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Models/Response/RecordResponseModel.cs)
- [Delete](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Services/YandexDnsApiService.cs#L105) DNS record
  - [Request Model](https://github.com/Silvochka/yandex-dns-api/blob/develop/YandexDnsAPI/YandexDnsAPI/Models/Request/DeleteDnsRequestModel.cs)
  - Response is id of deleted DNS record
