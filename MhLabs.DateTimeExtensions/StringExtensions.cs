using System;
using System.Text.RegularExpressions;

namespace MhLabs.DateTimeExtensions
{
    public static class StringExtensions
    {
        public static string ToClientDateTime(this string dateTimeValue)
        {
            var result = ParseLocal(dateTimeValue)?.ToClientDateTime() ?? string.Empty;
            return result;
        }

        public static string ToClientDate(this string dateTimeValue)
        {
            var result = ParseLocal(dateTimeValue)?.ToClientDate() ?? string.Empty;
            return result;
        }

        public static string FormatClientTime(this string dateTimeValue)
        {
            var result = ParseLocal(dateTimeValue)?.FormatClientTime() ?? string.Empty;
            return result;
        }

        public static string FormatClientDate(this string dateTimeValue)
        {
            var result = ParseLocal(dateTimeValue)?.FormatClientDate() ?? string.Empty;
            return result;
        }

        public static DateTime? ParseLocal(string dateTimeValue)
        {
            if (string.IsNullOrWhiteSpace(dateTimeValue)) return null;

            // expected format is: +dd:dd or -dd:dd at end, e.g. +02:00
            var hasTimeZoneRegex = @"^.*[\+|\-]\d{2}:\d{2}$";
            var hasTimeZone = Regex.IsMatch(dateTimeValue, hasTimeZoneRegex);

            if (hasTimeZone) return ConvertToLocal(dateTimeValue);

            if (!DateTime.TryParse(dateTimeValue, out var dateTime)) return null;
            return dateTime;
        }

        public static DateTime? ConvertToLocal(string dateTimeValue)
        {
            if (!DateTimeOffset.TryParse(dateTimeValue, out var offset)) return null;
            var result = offset.UtcDateTime.ToLocal();

            return result;
        }
    }
}