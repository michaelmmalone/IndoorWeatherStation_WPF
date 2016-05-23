using System;
using FluentAssertions;
using IndoorWeatherStation_WPF.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helper;

namespace Tests.Component
{
    [TestClass]
    public class MinuteDayChangeMonitorStrategyTests
    {
        [TestMethod]
        [TestCategory("Component")]
        public void StopMonitoring_EndOfIntervalCallbackNotCalledAfterwards()
        {
            // Arrange
            MinuteDayChangeMonitorStrategy target = new MinuteDayChangeMonitorStrategy();
            int callBackCount = 0;

            target.StartMonitoring(TimeSpan.FromMilliseconds(200), () => callBackCount++);

            // Act
            Waiter.Until(() => callBackCount > 0);
            target.StopMonitoring();
            Waiter.Until(() =>
            {
                bool result = callBackCount == 0;

                callBackCount = 0;
                return result;
            });

            // Assert
            callBackCount.Should().Be(0);
        }
    }
}
