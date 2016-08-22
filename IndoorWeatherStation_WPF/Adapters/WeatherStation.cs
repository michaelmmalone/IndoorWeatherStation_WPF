using System;
using System.Diagnostics;
using IndoorWeatherStation_WPF.ApplicationModel;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;
using IndoorWeatherStation_WPF.Simulators;

namespace IndoorWeatherStation_WPF.Adapters
{
    internal class WeatherStation : IWeatherStation
    {
        private readonly MinuteDayChangeMonitor minuteDayChangeMonitor;
        private readonly WeatherMonitor outdoorWeatherMonitor;
        private IWeather outdoorWeather;
        private readonly WeatherMonitor indoorWeatherMonitor;
        private IWeather indoorWeather;
        private bool isDisposed;

        #region IWeatherStation

        public event EventHandler<Time> MinuteChanged
        {
            add { this.minuteDayChangeMonitor.MinuteChanged += value; }
            remove { this.minuteDayChangeMonitor.MinuteChanged -= value; }
        }

        public event EventHandler<Date> DayChanged
        {
            add { this.minuteDayChangeMonitor.DayChanged += value; }
            remove { this.minuteDayChangeMonitor.DayChanged -= value; }
        }

        public event EventHandler<Temperature> OutdoorTemperatureChanged
        {
            add { this.outdoorWeatherMonitor.TemperatureChanged += value; }
            remove { this.outdoorWeatherMonitor.TemperatureChanged -= value; }
        }

        public event EventHandler<Humidity> OutdoorHumidityChanged
        {
            add { this.outdoorWeatherMonitor.HumidityChanged += value; }
            remove { this.outdoorWeatherMonitor.HumidityChanged += value; }
        }

        public event EventHandler<Temperature> IndoorTemperatureChanged
        {
            add { this.indoorWeatherMonitor.TemperatureChanged += value; }
            remove { this.indoorWeatherMonitor.TemperatureChanged -= value; }
        }

        public event EventHandler<Humidity> IndoorHumidityChanged
        {
            add { this.indoorWeatherMonitor.HumidityChanged += value; }
            remove { this.indoorWeatherMonitor.HumidityChanged += value; }
        }

        public WeatherStation()
        {
            this.minuteDayChangeMonitor = new MinuteDayChangeMonitor(
                new DateTimeSource(),
                new MinuteDayChangeMonitorStrategy());

            //TODO:
            this.outdoorWeather = new CdyneWeatherAdapter();
            //this.outdoorWeather = new NdfdWeatherAdapter();

            this.outdoorWeatherMonitor = new WeatherMonitor(
                this.outdoorWeather,
                new WeatherMonitorStrategy());

            this.indoorWeather = new WeatherSimulator();
            this.indoorWeatherMonitor = new WeatherMonitor(
                this.indoorWeather,
                new WeatherMonitorStrategy());
        }

        public void Start()
        {
            Debug.Assert(
                !this.isDisposed,
                "Why is Start being called after WeatherStation has been disposed?");

            this.minuteDayChangeMonitor.Start(TimeSpan.FromSeconds(2));
            this.outdoorWeatherMonitor.Start(TimeSpan.FromMinutes(5));
            this.indoorWeatherMonitor.Start(TimeSpan.FromMinutes(5));
        }

        public void Stop()
        {
            Debug.Assert(
                !this.isDisposed,
                "Why is Stop being called after WeatherStation has been disposed?");

            this.outdoorWeatherMonitor.Stop();
            this.indoorWeatherMonitor.Stop();
            this.minuteDayChangeMonitor.Stop();
        }

        public void Dispose()
        {
            this.Stop();

            if (this.outdoorWeather != null)
            {
                this.outdoorWeather.Dispose();
                this.outdoorWeather = null;
            }

            if (this.indoorWeather != null)
            {
                this.indoorWeather.Dispose();
                this.indoorWeather = null;
            }

            this.isDisposed = true;
        }

        #endregion IWeatherStation
    }
}