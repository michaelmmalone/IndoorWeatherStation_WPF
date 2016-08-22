using System;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace Tests.Mocks
{
    internal class IWeatherStationMock : IWeatherStation
    {
        public void RaiseMinuteChanged(Time newTime)
        {
            if (this.MinuteChanged != null)
            {
                this.MinuteChanged(this, newTime);
            }
        }

        public void RaiseDayChanged(Date newDate)
        {
            if (this.DayChanged != null)
            {
                this.DayChanged(this, newDate);
            }
        }

        public void RaiseOutdoorTemperatureChanged(Temperature newTemperature)
        {
            if (this.OutdoorTemperatureChanged != null)
            {
                this.OutdoorTemperatureChanged(this, newTemperature);
            }
        }

        public void RaiseOutdoorHumidityChanged(Humidity newHumidity)
        {
            if (this.OutdoorHumidityChanged != null)
            {
                this.OutdoorHumidityChanged(this, newHumidity);
            }
        }

        public void RaiseIndoorTemperatureChanged(Temperature newTemperature)
        {
            if (this.IndoorTemperatureChanged != null)
            {
                this.IndoorTemperatureChanged(this, newTemperature);
            }
        }

        public void RaiseIndoorHumidityChanged(Humidity newHumidity)
        {
            if (this.IndoorHumidityChanged != null)
            {
                this.IndoorHumidityChanged(this, newHumidity);
            }
        }

        #region IWeatherStation

        public event EventHandler<Time> MinuteChanged;
        public event EventHandler<Date> DayChanged;
        public event EventHandler<Temperature> OutdoorTemperatureChanged;
        public event EventHandler<Humidity> OutdoorHumidityChanged;
        public event EventHandler<Temperature> IndoorTemperatureChanged;
        public event EventHandler<Humidity> IndoorHumidityChanged;

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