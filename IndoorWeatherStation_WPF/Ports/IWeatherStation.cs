using System;
using IndoorWeatherStation_WPF.DomainModel;

namespace IndoorWeatherStation_WPF.Ports
{
    internal interface IWeatherStation : IDisposable
    {
        event EventHandler<Time> MinuteChanged;
        event EventHandler<DateTime> DayChanged;
        event EventHandler<Temperature> OutdoorTemperatureChanged;
        event EventHandler<Humidity> OutdoorHumidityChanged;
        event EventHandler<Temperature> IndoorTemperatureChanged;
        event EventHandler<Humidity> IndoorHumidityChanged;

        void Start();
        void Stop();
    }
}