using System;
using IndoorWeatherStation_WPF.Ports;

namespace Tests.Mocks
{
    internal class IWeatherStationMock : IWeatherStation
    {
        public void RaiseMinuteChanged(DateTime newTime)
        {
            if (this.MinuteChanged != null)
            {
                this.MinuteChanged(this, newTime);
            }
        }

        public void RaiseDayChanged(DateTime newDate)
        {
            if (this.DayChanged != null)
            {
                this.DayChanged(this, newDate);
            }
        }

        public void RaiseOutdoorTemperatureChanged(int newTemperature)
        {
            if (this.OutdoorTemperatureChanged != null)
            {
                this.OutdoorTemperatureChanged(this, newTemperature);
            }
        }

        public void RaiseOutdoorHumidityChanged(int newHumidity)
        {
            if (this.OutdoorHumidityChanged != null)
            {
                this.OutdoorHumidityChanged(this, newHumidity);
            }
        }

        public void RaiseIndoorTemperatureChanged(int newTemperature)
        {
            if (this.IndoorTemperatureChanged != null)
            {
                this.IndoorTemperatureChanged(this, newTemperature);
            }
        }

        public void RaiseIndoorHumidityChanged(int newHumidity)
        {
            if (this.IndoorHumidityChanged != null)
            {
                this.IndoorHumidityChanged(this, newHumidity);
            }
        }

        #region IWeatherStation

        public event EventHandler<DateTime> MinuteChanged;
        public event EventHandler<DateTime> DayChanged;
        public event EventHandler<int> OutdoorTemperatureChanged;
        public event EventHandler<int> OutdoorHumidityChanged;
        public event EventHandler<int> IndoorTemperatureChanged;
        public event EventHandler<int> IndoorHumidityChanged;

        public void Start()
        {
            throw new NotImplementedException();
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