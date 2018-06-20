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


    }
}