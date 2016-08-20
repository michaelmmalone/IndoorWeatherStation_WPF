using System;
using System.Diagnostics;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.ApplicationModel
{
    [DebuggerDisplay("lastSavedTemperature={lastSavedTemperature_New}, lastSavedHumidity={lastSavedHumidity_New}")]
    internal class WeatherMonitor
    {
        private readonly IWeather weather;
        private readonly IWeatherMonitorStrategy monitorStrategy;
        private Temperature lastSavedTemperature_New;
        private Humidity lastSavedHumidity_New;

        public event EventHandler<int> TemperatureChanged;
        public event EventHandler<Temperature> TemperatureChanged_New;
        public event EventHandler<int> HumidityChanged;
        public event EventHandler<Humidity> HumidityChanged_New;

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

        private void RaiseTemperatureChanged(Temperature temperature)
        {
            if (this.TemperatureChanged_New != null)
            {
                this.TemperatureChanged_New(this, temperature);
            }
        }

        private void RaiseHumidityChanged(int humidity)
        {
            if (this.HumidityChanged != null)
            {
                this.HumidityChanged(this, humidity);
            }
        }

        private void RaiseHumidityChanged_New(Humidity humidity)
        {
            if (this.HumidityChanged_New != null)
            {
                this.HumidityChanged_New(this, humidity);
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
            if (weatherData.Temperature_New != this.lastSavedTemperature_New)
            {
                this.lastSavedTemperature_New = weatherData.Temperature_New;
                this.RaiseTemperatureChanged(weatherData.Temperature);
                this.RaiseTemperatureChanged(weatherData.Temperature_New);
            }
        }

        private void SendHumidityUpdate(WeatherData weatherData)
        {
            if (weatherData.Humidity_New != this.lastSavedHumidity_New)
            {
                this.lastSavedHumidity_New = weatherData.Humidity_New;
                this.RaiseHumidityChanged(weatherData.Humidity);
                this.RaiseHumidityChanged_New(weatherData.Humidity_New);
            }
        }
    }
}
