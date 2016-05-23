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
        private int lastSavedTemperature;
        private int lastSavedHumidity;

        public event EventHandler<int> TemperatureChanged;
        public event EventHandler<int> HumidityChanged;

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

        private void RaiseTemperatureChanged(int temperature)
        {
            if (this.TemperatureChanged != null)
            {
                this.TemperatureChanged(this, temperature);
            }
        }

        private void RaiseHumidityChanged(int humidity)
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
            if (weatherData.Temperature != this.lastSavedTemperature)
            {
                this.lastSavedTemperature = weatherData.Temperature;
                this.RaiseTemperatureChanged(weatherData.Temperature);
            }
        }

        private void SendHumidityUpdate(WeatherData weatherData)
        {
            if (weatherData.Humidity != this.lastSavedHumidity)
            {
                this.lastSavedHumidity = weatherData.Humidity;
                this.RaiseHumidityChanged(weatherData.Humidity);
            }
        }
    }
}
