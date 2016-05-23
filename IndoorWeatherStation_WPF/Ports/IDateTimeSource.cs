using System;

namespace IndoorWeatherStation_WPF.Ports
{
    internal interface IDateTimeSource
    {
        DateTime Now { get; }
    }
}