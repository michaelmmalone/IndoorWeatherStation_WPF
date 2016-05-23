using System;

namespace IndoorWeatherStation_WPF.Ports
{
    internal interface IMinuteDayChangeMonitorStrategy
    {
        void StartMonitoring(TimeSpan interval, Action actionAtEndOfInterval);
        void StopMonitoring();
    }
}