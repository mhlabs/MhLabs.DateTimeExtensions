using System;

namespace MhLabs.DateTimeExtensions
{
    public static class StringExtensions
    {
        public static string ToClientDateTime(this string dateTimeValue)
        {
            if (!DateTime.TryParse(dateTimeValue, out var dateTime)) return string.Empty;
            return dateTime.ToClientDateTime();
        }

        public static string ToClientDate(this string dateTimeValue)
        {
            if (!DateTime.TryParse(dateTimeValue, out var dateTime)) return string.Empty;
            return dateTime.ToClientDate();
        }
    }
}