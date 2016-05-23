using System;
using IndoorWeatherStation_WPF.Ports;

namespace Tests.Mocks
{
    internal class IWeatherMonitorStrategyMock : IWeatherMonitorStrategy
    {
        public void StartMonitoring(TimeSpan interval, Action actionAtEndOfInterval)
        {
            actionAtEndOfInterval();
        }

        public void StopMonitoring()
        {
            throw new NotImplementedException();
        }
    }
}