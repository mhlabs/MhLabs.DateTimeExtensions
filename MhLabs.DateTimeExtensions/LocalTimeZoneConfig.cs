using System;

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
            _tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return _tz;
        }

        public static TimeZoneInfo Create(string timeZoneId)
        {
            var zoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return zoneInfo;
        }

        public static void Reset()
        {
            _tz = null;
        }

    }
}