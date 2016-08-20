using System;
using System.Threading.Tasks;
using IndoorWeatherStation_WPF.CdyneWeather;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.Adapters
{
    internal class CdyneWeatherAdapter : IWeather
    {
        private WeatherSoapClient proxy = new WeatherSoapClient("WeatherSoap");

        #region IWeather

        public async Task<WeatherData> GetWeatherAsync()
        {
            if (this.IsDisposed)
            {
                return await Task.FromResult(WeatherData.Empty);
            }

            return await this.proxy.GetCityWeatherByZIPAsync("98008").ContinueWith(t =>
            {
                return !this.IsDisposed && t.Result.Success 
                    ? CdyneWeatherAdapter.CreateWeatherData(t.Result) 
                    : WeatherData.Empty;
            });
        }

        void IDisposable.Dispose()
        {
            this.IsDisposed = true;

            if (this.proxy != null)
            {
                this.proxy.Close();
                this.proxy = null;
            }
        }

        #endregion IWeather

        private static WeatherData CreateWeatherData(WeatherReturn weatherFromService)
        {
            return new WeatherData(
                new Temperature(int.Parse(weatherFromService.Temperature)),
                new Humidity(int.Parse(weatherFromService.RelativeHumidity)));
        }

        private bool IsDisposed { get; set; }
    }
}