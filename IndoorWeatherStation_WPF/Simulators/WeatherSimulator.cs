using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.Simulators
{
    internal class WeatherSimulator : IWeather
    {
        private static readonly Random RandomNumber = new Random();
        private List<WeatherData> weatherDataForGetWeatherAsync;

        public bool UseRandomValues { get; set; }

        public void GetWeatherAsync_Returns(params WeatherData[] weatherDataValues)
        {
            this.weatherDataForGetWeatherAsync = weatherDataValues.ToList();
        }

        #region IWeather

        public Task<WeatherData> GetWeatherAsync()
        {
            return Task.FromResult(new WeatherData(
                WeatherSimulator.RandomNumber.Next(32, 76),
                WeatherSimulator.RandomNumber.Next(10, 101)));
        }

        public void Dispose()
        {
            // Nothing to do.
        }

        #endregion IWeather
    }
}
