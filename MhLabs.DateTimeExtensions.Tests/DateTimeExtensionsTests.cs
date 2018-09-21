using Xunit;
using System;
using FluentAssertions;

namespace MhLabs.DateTimeExtensions.Tests
{
    [Collection(nameof(MhLabs.DateTimeExtensions))]
    public class DateTimeExtensionsTests
    {
        public DateTimeExtensionsTests()
        {
            LocalTimeZoneConfig.Reset();
        }

        [Fact]
        public void Should_Convert_To_Local_Time_Zone()
        {
            var sweden = LocalTimeZoneConfig.Init(TimeZones.Sweden);

            var timeIn = DateTime.UtcNow.ToLocal();
            timeIn.Should().BeAfter(DateTime.UtcNow);
        }

        [Fact]
        public void Should_Convert_Utc_To_Local_Time()
        {
            var sweden = LocalTimeZoneConfig.Init(TimeZones.Sweden);

            var timeIn = DateTime.Now.In(sweden);
            timeIn.Should().BeAfter(DateTime.UtcNow);

            var timeLocal = DateTime.Now.ToLocal();
            timeLocal.Should().BeAfter(DateTime.UtcNow);
        }

        [Fact]
        public void Should_Convert_To_Different_Local_Time_Zone()
        {
            var sweden = LocalTimeZoneConfig.Init(TimeZones.Sweden);
            var usEast = LocalTimeZoneConfig.Create(TimeZones.UsEastern);

            var timeLocal = DateTime.Now.In(usEast);
            timeLocal.Should().BeBefore(DateTime.UtcNow);
        }

        [Fact]
        public void Should_Convert_To_Client_Date()
        {
            LocalTimeZoneConfig.Init(TimeZones.Utc);

            var date = new DateTime(2099, 12, 5);
            var clientFormat = date.ToClientDate();

            clientFormat.Should().Be("2099-12-05T00:00:00+00:00");
        }

        [Fact]
        public void Should_Convert_To_Client_DateTime_With_Local_Kind()
        {
            LocalTimeZoneConfig.Init(TimeZones.UsEastern);

            var date = new DateTime(2099, 12, 5, 13, 17, 27, DateTimeKind.Local);
            var clientFormat = date.ToClientDateTime();

            clientFormat.Should().Be("2099-12-05T13:17:27-05:00");
        }

        [Fact]
        public void Should_Convert_To_Client_DateTime()
        {
            LocalTimeZoneConfig.Init(TimeZones.Utc);

            var date = new DateTime(2099, 12, 5, 13, 17, 27);
            var clientFormat = date.ToClientDateTime();

            clientFormat.Should().Be("2099-12-05T13:17:27+00:00");
        }

    }
}