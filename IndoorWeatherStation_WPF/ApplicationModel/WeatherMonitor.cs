using System;
using System.Diagnostics;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.ApplicationModel
{
    [DebuggerDisplay("lastSavedTemperature={lastSavedTemperature}, lastSavedHumidity={lastSavedHumidity}")]
    internal class WeatherMonitor
    {
        private readonly IWeather weather;
        private readonly IWeatherMonitorStrategy monitorStrategy;
        private Temperature lastSavedTemperature;
        private Humidity lastSavedHumidity;

        public event EventHandler<Temperature> TemperatureChanged;
        public event EventHandler<Humidity> HumidityChanged;

        public WeatherMonitor(IWeather weather, IWeatherMonitorStrategy monitorStrategy)
        {
            this.weather = weather;
            this.monitorStrategy = monitorStrategy;
        }

        public void Start(TimeSpan interval)
        {
            this.monitorStrategy.StartMonitoring(interval, this.SendUpdates);
        }

        public void Stop()
        {
            this.monitorStrategy.StopMonitoring();
        }

        private void RaiseTemperatureChanged(Temperature temperature)
        {
            if (this.TemperatureChanged != null)
            {
                this.TemperatureChanged(this, temperature);
            }
        }

        private void RaiseHumidityChanged_New(Humidity humidity)
        {
            if (this.HumidityChanged != null)
            {
                this.HumidityChanged(this, humidity);
            }
        }

        private async void SendUpdates()
        {
            WeatherData weatherData = await this.weather.GetWeatherAsync();

            this.SendTemperatureUpdate(weatherData);
            this.SendHumidityUpdate(weatherData);
        }

        private void SendTemperatureUpdate(WeatherData weatherData)
        {
            if (weatherData.Temperature_New != this.lastSavedTemperature)
            {
                this.lastSavedTemperature = weatherData.Temperature_New;
                this.RaiseTemperatureChanged(weatherData.Temperature_New);
            }
        }

        private void SendHumidityUpdate(WeatherData weatherData)
        {
            if (weatherData.Humidity_New != this.lastSavedHumidity)
            {
                this.lastSavedHumidity = weatherData.Humidity_New;
                this.RaiseHumidityChanged_New(weatherData.Humidity_New);
            }
        }
    }
}
