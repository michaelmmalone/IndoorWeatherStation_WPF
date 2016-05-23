using System;
using IndoorWeatherStation_WPF.Ports;

namespace Tests.Mocks
{
    internal class IMinuteDayChangeMonitorStrategyMock : IMinuteDayChangeMonitorStrategy
    {
        public static IMinuteDayChangeMonitorStrategyMock Create()
        {
            return new IMinuteDayChangeMonitorStrategyMock();
        }

        #region IMinuteDayChangeMonitorStrategy

        public void StartMonitoring(TimeSpan interval, Action actionAtEndOfInterval)
        {
            actionAtEndOfInterval();
        }

        public void StopMonitoring()
        {
            // Nothing to do.
        }

        #endregion IMinuteDayChangeMonitorStrategy
    }
}
