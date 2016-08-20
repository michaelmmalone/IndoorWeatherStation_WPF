using System.Threading.Tasks;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace Tests.Mocks
{
    internal class IWeatherMock : IWeather
    {
        public WeatherData GetWeatherAsync_Returns { get; set; }

        #region IWeather

        public Task<Temperature> GetTemperatureAsync()
        {
            return Task.FromResult(this.GetWeatherAsync_Returns.Temperature_New);
        }

        public Task<WeatherData> GetWeatherAsync()
        {
            return Task.FromResult(this.GetWeatherAsync_Returns);
        }

        public void Dispose()
        {
            // Nothing to do.
        }

        #endregion
    }
}