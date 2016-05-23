using System;

namespace IndoorWeatherStation_WPF.Ports
{
    internal interface IWeatherMonitorStrategy
    {
        void StartMonitoring(TimeSpan interval, Action actionAtEndOfInterval);
        void StopMonitoring();
    }
}