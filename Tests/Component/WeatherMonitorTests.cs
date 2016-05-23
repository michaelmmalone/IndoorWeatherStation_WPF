using System;
using FluentAssertions;
using IndoorWeatherStation_WPF.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fixtures;
using Tests.Helper;

namespace Tests.Component
{
    [TestClass]
    public class WeatherMonitorTests
    {
        [TestMethod]
        [TestCategory("Component")]
        public void ChangeInTemperature_TemperatureChangedEventRaised()
        {
            // Arrange
            WeatherMonitorFixture weatherMonitorFixture = new WeatherMonitorFixture();
            int result = 0;
            WeatherData expected = new WeatherData(temperature: 52, humidity: 0);

            weatherMonitorFixture.SetExpectedWeatherData(expected);
            weatherMonitorFixture.Target.TemperatureChanged += (sender, newTemp) => result = newTemp;

            // Act
            weatherMonitorFixture.Target.Start(TimeSpan.FromMilliseconds(0) /*not used*/);
            Waiter.Until(() => result != 0);

            // Assert
            result.Should().Be(expected.Temperature);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void ChangeInHumidity_HumidityChangedEventRaised()
        {
            // Arrange
            WeatherMonitorFixture weatherMonitorFixture = new WeatherMonitorFixture();
            int result = 0;
            WeatherData expected = new WeatherData(temperature: 0, humidity: 60);

            weatherMonitorFixture.SetExpectedWeatherData(expected);
            weatherMonitorFixture.Target.HumidityChanged += (sender, newHumidity) => result = newHumidity;

            // Act
            weatherMonitorFixture.Target.Start(TimeSpan.FromMilliseconds(0) /*not used*/);
            Waiter.Until(() => result != 0);

            // Assert
            result.Should().Be(expected.Humidity);
        }
    }
}
