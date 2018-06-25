using Xunit;
using System;
using FluentAssertions;

namespace MhLabs.DateTimeExtensions.Tests
{
    [Collection(nameof(MhLabs.DateTimeExtensions))]
    public class StringExtensionTests
    {
        public StringExtensionTests()
        {
            LocalTimeZoneConfig.Reset();
        }

        [Fact]
        public void Should_Convert_To_Client_Date()
        {
            LocalTimeZoneConfig.Init(TimeZones.Utc);

            var date = "2099-12-05";
            var clientFormat = date.ToClientDate();

            clientFormat.Should().Be("2099-12-05T00:00:00+00:00");
        }

        [Fact]
        public void Should_Convert_To_Client_DateTime()
        {
            LocalTimeZoneConfig.Init(TimeZones.Utc);

            var date = "2099-12-05 13:17:27";
            var clientFormat = date.ToClientDateTime();

            clientFormat.Should().Be("2099-12-05T13:17:27+00:00");
        }

        [Fact]
        public void Should_Convert_To_Client_DateTime_With_Time_Zone()
        {
            LocalTimeZoneConfig.Init(TimeZones.Sweden);

            var date = "2099-12-05T13:17:27+00:00";
            var clientFormat = date.ToClientDateTime();

            clientFormat.Should().Be("2099-12-05T14:17:27+01:00");
        }

        [Fact]
        public void Should_Format_Client_Date()
        {
            LocalTimeZoneConfig.Init(TimeZones.Utc);

            var date = "2018-06-25T01:00:00+02:00";
            var clientFormat = date.FormatClientDate();

            clientFormat.Should().Be("2018-06-24");
        }

        [Fact]
        public void Should_Format_Client_Time()
        {
            LocalTimeZoneConfig.Init(TimeZones.Sweden);

            var date = "2018-06-25T21:15:00+02:00";
            var clientFormat = date.FormatClientTime();

            clientFormat.Should().Be("21:15");
        }

        [Fact]
        public void Should_Format_Client_Time_Without_Time_Zone()
        {
            LocalTimeZoneConfig.Init(TimeZones.Utc);

            var date = "2018-06-25 21:15:00";
            var clientFormat = date.FormatClientTime();

            clientFormat.Should().Be("21:15");
        }

    }
}