using System;
using IndoorWeatherStation_WPF.Adapters;
using IndoorWeatherStation_WPF.ApplicationModel;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.Simulators
{
    internal class WeatherStationSimulator : IWeatherStation
    {
        private readonly MinuteDayChangeMonitor minuteDayChangeMonitor;
        private readonly WeatherMonitor outdoorWeatherMonitor;
        private readonly WeatherMonitor indoorWeatherMonitor;

        public WeatherStationSimulator()
        {
            this.minuteDayChangeMonitor = new MinuteDayChangeMonitor(
                new DateTimeSourceSimulator(), 
                new MinuteDayChangeMonitorStrategy());

            this.outdoorWeatherMonitor = new WeatherMonitor(
                new WeatherSimulator(),
                new WeatherMonitorStrategy());

            this.indoorWeatherMonitor = new WeatherMonitor(
                new WeatherSimulator(),
                new WeatherMonitorStrategy());
        }

        #region IWeatherStation

        public event EventHandler<Time> MinuteChanged
        {
            add { this.minuteDayChangeMonitor.MinuteChanged += value; }
            remove { this.minuteDayChangeMonitor.MinuteChanged -= value; }
        }

        public event EventHandler<DateTime> DayChanged
        {
            add { this.minuteDayChangeMonitor.DayChanged += value; }
            remove { this.minuteDayChangeMonitor.DayChanged -= value; }
        }

        public event EventHandler<Time> DayChanged_New;

        public event EventHandler<Temperature> OutdoorTemperatureChanged
        {
            add { this.outdoorWeatherMonitor.TemperatureChanged += value; }
            remove { this.outdoorWeatherMonitor.TemperatureChanged -= value; }
        }

        public event EventHandler<int> OutdoorHumidityChanged
        {
            add { this.outdoorWeatherMonitor.HumidityChanged += value; }
            remove { this.outdoorWeatherMonitor.HumidityChanged += value; }
        }

        public event EventHandler<Temperature> IndoorTemperatureChanged
        {
            add { this.indoorWeatherMonitor.TemperatureChanged += value; }
            remove { this.indoorWeatherMonitor.TemperatureChanged -= value; }
        }

        public event EventHandler<int> IndoorHumidityChanged
        {
            add { this.indoorWeatherMonitor.HumidityChanged += value; }
            remove { this.indoorWeatherMonitor.HumidityChanged += value; }
        }

        public void Start()
        {
            this.minuteDayChangeMonitor.Start(TimeSpan.FromSeconds(2));
            this.outdoorWeatherMonitor.Start(TimeSpan.FromSeconds(2));
            this.indoorWeatherMonitor.Start(TimeSpan.FromSeconds(2));
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Nothing to do.
        }

        #endregion IWeatherStation
    }
}
