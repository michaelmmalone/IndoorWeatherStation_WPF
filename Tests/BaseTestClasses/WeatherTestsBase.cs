using FluentAssertions;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace Tests.BaseTestClasses
{
    public abstract class WeatherTestsBase
    {
        public virtual void GetWeatherAsync_ReturnsGoodValues()
        {
            // Arrange
            using (IWeather target = this.GetWeather())
            {
                // Act
                WeatherData result = target.GetWeatherAsync().Result;

                // Assert
                result.Humidity_New.Should().NotBe(0);
                result.Temperature_New.Should().NotBe(0);
            }
        }

        internal abstract IWeather GetWeather();
    }
}
