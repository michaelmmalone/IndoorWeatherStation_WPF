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
            Temperature result = null;
            WeatherData expected = new WeatherData(new Temperature(52), new Humidity(0));

            weatherMonitorFixture.SetExpectedWeatherData(expected);
            weatherMonitorFixture.Target.TemperatureChanged += (sender, newTemp) => result = newTemp;

            // Act
            weatherMonitorFixture.Target.Start(TimeSpan.FromMilliseconds(0) /*not used*/);
            Waiter.Until(() => result != null);

            // Assert
            result.Should().Be(expected.Temperature);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void ChangeInHumidity_HumidityChangedEventRaised()
        {
            // Arrange
            WeatherMonitorFixture weatherMonitorFixture = new WeatherMonitorFixture();
            Humidity result = null;
            WeatherData expected = new WeatherData(new Temperature(0), new Humidity(60));

            weatherMonitorFixture.SetExpectedWeatherData(expected);
            weatherMonitorFixture.Target.HumidityChanged += (sender, newHumidity) => result = newHumidity;

            // Act
            weatherMonitorFixture.Target.Start(TimeSpan.FromMilliseconds(0) /*not used*/);
            Waiter.Until(() => result != null);

            // Assert
            result.Should().Be(expected.Humidity);
        }
    }
}
