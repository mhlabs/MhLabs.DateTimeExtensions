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

        private static string ToClientFormat(DateTime dateTime, string format)
        {
            var offset = new DateTimeOffset(dateTime, LocalTimeZoneConfig.TimeZone.GetUtcOffset(dateTime));
            var result = offset.ToString(format);

            return result;
        }

    }
}