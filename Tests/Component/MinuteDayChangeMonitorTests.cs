using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fixtures;
using Tests.Helper;

namespace Tests.Component
{
    [TestClass]
    public class MinuteDayChangeMonitorTests
    {
        [TestMethod]
        [TestCategory("Component")]
        public void VerifyMinuteChangedEventIsRaised()
        {
            // Arrange
            MinuteDayChangeMonitorFixture fixture = new MinuteDayChangeMonitorFixture();
            int eventRaisedCount = 0;

            fixture.Target.MinuteChanged += (sender, args) => eventRaisedCount++;
            fixture.DateAndTimeValues(DateTime.Parse("6:20:00"), DateTime.Parse("6:21:00"));

            // Act
            Task.Run(() => fixture.Target.Start(TimeSpan.FromMilliseconds(200))).Wait();
            Waiter.Until(() => eventRaisedCount >= 2);

            // Assert
            eventRaisedCount.Should().BeGreaterOrEqualTo(2);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void VerifyDayChangedEventIsRaised()
        {
            // Arrange
            MinuteDayChangeMonitorFixture fixture = new MinuteDayChangeMonitorFixture();
            int eventRaisedCount = 0;

            fixture.Target.DayChanged += (sender, args) => eventRaisedCount++;
            fixture.DateAndTimeValues(DateTime.Parse("1/1/2015"), DateTime.Parse("1/2/2015"));

            // Act
            Task.Run(() => fixture.Target.Start(TimeSpan.FromMilliseconds(200))).Wait();
            Waiter.Until(() => eventRaisedCount >= 2);

            // Assert
            eventRaisedCount.Should().BeGreaterOrEqualTo(2);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void Stop_NoEventsRaisedAfterwards()
        {
            // Arrange
            MinuteDayChangeMonitorFixture fixture = new MinuteDayChangeMonitorFixture();
            int eventRaisedCount = 0;

            fixture.Target.MinuteChanged += (sender, args) => eventRaisedCount++;
            fixture.DateAndTimeValues(
                DateTime.Parse("6:20:00"), 
                DateTime.Parse("6:21:00"),
                DateTime.Parse("6:22:00"),
                DateTime.Parse("6:23:00"),
                DateTime.Parse("6:24:00"),
                DateTime.Parse("6:25:00"));

            Task.Run(() => fixture.Target.Start(TimeSpan.FromMilliseconds(300))).Wait();
            Waiter.Until(() => eventRaisedCount > 0);

            // Act
            fixture.Target.Stop();

            // Assert
            eventRaisedCount.Should().BeLessThan(6);
        }
    }
}
