using System;
using System.Threading;
using IndoorWeatherStation_WPF.Ports;
using IndoorWeatherStation_WPF.Utility;

namespace IndoorWeatherStation_WPF.Adapters
{
    internal class MinuteDayChangeMonitorStrategy : IMinuteDayChangeMonitorStrategy
    {
        private Timer timer;

        public void StartMonitoring(
            TimeSpan interval,
            Action actionAtEndOfInterval)
        {
            // Populate UI before interval is up so user doesn't have blank data to look at.
            actionAtEndOfInterval();

            this.timer = new Timer(
                state => Helper.RunOnUiThreadAndWait(actionAtEndOfInterval),
                null,
                new TimeSpan(-1),
                interval);
        }

        public void StopMonitoring()
        {
            this.timer.Dispose();
        }
    }
}