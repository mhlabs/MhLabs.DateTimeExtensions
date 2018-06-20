using System;
using Xunit;

namespace MhLabs.DateTimeExtensions.Tests
{
    [Collection(nameof(MhLabs.DateTimeExtensions))]
    public class TimeZoneConfigTests
    {
        public TimeZoneConfigTests()
        {
            LocalTimeZoneConfig.Reset();
        }

        [Fact]
        public void Should_Throw_If_Not_Initialized()
        {
            Assert.Throws<InvalidTimeZoneException>(() => LocalTimeZoneConfig.TimeZone);
        }
    }
}
