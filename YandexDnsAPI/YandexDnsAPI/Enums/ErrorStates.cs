namespace YandexDnsAPI.Enums
{
    public static class ErrorStates
    {
        public static string Unknown = "unknown";
        public static string NoToken = "no_token";
        public static string NoDomain = "no_domain";
        public static string NoIp = "no_ip";
        public static string BadDomain = "bad_domain";
        public static string Prohibited = "prohibited";
        public static string BadToken = "bad_token";
        public static string BadLogin = "bad_login";
        public static string BadPassword = "bad_passwd";
        public static string NoAuth = "no_auth";
        public static string NotAllowed = "not_allowed";
        public static string Blocked = "blocked";
        public static string Occupied = "occupied";
        public static string DomainLimitReached = "domain_limit_reached";
        public static string NoReply = "no_reply";
    }
}
