using System;

namespace YandexDnsAPI.Helpers
{
    internal static class ValidationHelper
    {
        public static void ThrowIfNullOrEmpty(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                throw new ArgumentNullException(nameof(param));
            }
        }

        public static void ThrowIfNotInBound(int? param, int minValue, int maxValue)
        {
            if (param.HasValue && (param < minValue || param > maxValue))
            {
                throw new ArgumentOutOfRangeException(nameof(param));
            }
        }

        public static void ThrowIfNull(int? param)
        {
            if (!param.HasValue)
            {
                throw new ArgumentNullException(nameof(param));
            }
        }

        public static void ThrowIfNull(object param)
        {
            if (param == null)
            {
                throw new ArgumentNullException(nameof(param));
            }
        }

        public static void ThrowIfFalse(bool value, string message)
        {
            if (!value)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
