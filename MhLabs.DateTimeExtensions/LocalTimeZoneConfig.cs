using System;
using TimeZoneConverter;

namespace MhLabs.DateTimeExtensions
{
    public static class LocalTimeZoneConfig
    {
        private static TimeZoneInfo _tz;
        public static TimeZoneInfo TimeZone
        {
            get
            {
                if (_tz == null) throw new InvalidTimeZoneException("TimeZoneConfig has not been initialized. Call Init.");
                return _tz;
            }
        }

        public static TimeZoneInfo Init(string timeZoneId)
        {
            _tz = TZConvert.GetTimeZoneInfo(timeZoneId);
            return _tz;
        }

        public static TimeZoneInfo Create(string timeZoneId)
        {
            var zoneInfo = TZConvert.GetTimeZoneInfo(timeZoneId);
            return zoneInfo;
        }

        public static void Reset()
        {
            _tz = null;
        }

    }
}