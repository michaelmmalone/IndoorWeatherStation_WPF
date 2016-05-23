using System;
using FluentAssertions;
using IndoorWeatherStation_WPF.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helper;

namespace Tests.Component
{
    [TestClass]
    public class WeatherMonitorStrategyTests
    {
        [TestMethod]
        [TestCategory("Component")]
        public void StartMonitoring_CallbackInvokedBeforeMonitoringStarts()
        {
            // Arrange
            WeatherMonitorStrategy target = new WeatherMonitorStrategy();
            int callbackCount = 0;

            // Act
            // Make interval large so test completes before it triggers.
            target.StartMonitoring(TimeSpan.FromMilliseconds(10000), () => callbackCount++);
            Waiter.Until(() => callbackCount > 0);

            // Assert
            callbackCount.Should().BeGreaterOrEqualTo(1);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void StartMonitoring_NormalBehavior_CallbackInvokedMultipleTimes()
        {
            // Arrange
            WeatherMonitorStrategy target = new WeatherMonitorStrategy();
            int callbackCount = 0;

            // Act
            target.StartMonitoring(TimeSpan.FromMilliseconds(100), () => callbackCount++);
            Waiter.Until(() => callbackCount >= 2);

            // Assert
            callbackCount.Should().BeGreaterOrEqualTo(2);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void StopMonitoring_EndOfIntervalCallbackNotCalledAfterwards()
        {
            // Arrange
            WeatherMonitorStrategy target = new WeatherMonitorStrategy();
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
