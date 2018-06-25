using System;

namespace MhLabs.DateTimeExtensions
{
    public static class DateTimeExtensions
    {
        public static DateTime In(this DateTime dateTime, TimeZoneInfo timeZoneInfo)
        {
            var result = TimeZoneInfo.ConvertTime(dateTime, timeZoneInfo);
            return result;
        }

        public static DateTime ToLocal(this DateTime dateTime) => In(dateTime, LocalTimeZoneConfig.TimeZone);

        public static string ToClientDateTime(this DateTime dateTime)
        {
            return ToClientFormat(dateTime, "yyyy-MM-dd'T'HH:mm:sszzz");
        }

        public static string ToClientDate(this DateTime dateTime)
        {
            return ToClientFormat(dateTime, "yyyy-MM-dd'T'00:00:00zzz");
        }

        public static string FormatClientTime(this DateTime dateTime)
        {
            return ToClientFormat(dateTime, "HH:mm");
        }

        public static string FormatClientDate(this DateTime dateTime)
        {
            return ToClientFormat(dateTime, "yyyy-MM-dd");
        }

        private static string ToClientFormat(DateTime dateTime, string format)
        {
            if (dateTime == DateTime.MinValue) return string.Empty;

            var offsetSpan = LocalTimeZoneConfig.TimeZone.GetUtcOffset(dateTime);
            var offset = new DateTimeOffset(dateTime.Ticks, offsetSpan);

            var result = offset.ToString(format);
            return result;
        }

    }
}