using IndoorWeatherStation_WPF.ApplicationModel;
using IndoorWeatherStation_WPF.DomainModel;
using Tests.Mocks;

namespace Tests.Fixtures
{
    internal class WeatherMonitorFixture
    {
        private readonly IWeatherMock weatherMock;

        public WeatherMonitorFixture()
        {
            IWeatherMonitorStrategyMock weatherMonitorStrategy =
                new IWeatherMonitorStrategyMock();

            weatherMock = new IWeatherMock();

            this.Target = new WeatherMonitor(
                weatherMock,
                weatherMonitorStrategy);
        }

        public WeatherMonitor Target { get; private set; }

        public void SetExpectedWeatherData(WeatherData expected)
        {
            this.weatherMock.GetWeatherAsync_Returns = expected;
        }
    }
}
