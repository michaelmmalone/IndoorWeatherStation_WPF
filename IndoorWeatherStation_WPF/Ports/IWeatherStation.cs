using System;

namespace IndoorWeatherStation_WPF.Ports
{
    internal interface IWeatherStation : IDisposable
    {
        event EventHandler<DateTime> MinuteChanged;
        event EventHandler<DateTime> DayChanged;
        event EventHandler<int> OutdoorTemperatureChanged;
        event EventHandler<int> OutdoorHumidityChanged;
        event EventHandler<int> IndoorTemperatureChanged;
        event EventHandler<int> IndoorHumidityChanged;

        void Start();
        void Stop();
    }
}