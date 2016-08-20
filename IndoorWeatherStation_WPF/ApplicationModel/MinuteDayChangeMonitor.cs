using System;
using System.Diagnostics;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.ApplicationModel
{
    [DebuggerDisplay("lastSavedMinute={lastSavedMinute}, lastSavedDay={lastSavedDay}")]
    internal class MinuteDayChangeMonitor
    {
        public event EventHandler<Time> MinuteChanged;
        public event EventHandler<DateTime> DayChanged;

        private int lastSavedMinute;
        private int lastSavedDay;
        private readonly IDateTimeSource dateTimeSource;
        private readonly IMinuteDayChangeMonitorStrategy monitorStrategy;

        public MinuteDayChangeMonitor(
            IDateTimeSource dateTimeSource,
            IMinuteDayChangeMonitorStrategy monitorStrategy)  //TODO: call a method instead.
        {
            this.dateTimeSource = dateTimeSource;
            this.monitorStrategy = monitorStrategy;
        }

        public void Start(TimeSpan interval)
        {
            DateTime startingDateTime = DateTime.Now;

            this.RaiseMinuteChanged(startingDateTime);
            this.RaiseDayChanged(startingDateTime);

            this.monitorStrategy.StartMonitoring(interval, this.SendUpdates);
        }

        public void Stop()
        {
            this.monitorStrategy.StopMonitoring();
        }

        private void RaiseMinuteChanged(DateTime newTime)
        {
            if (this.MinuteChanged != null)
            {
                this.MinuteChanged(this, new Time(newTime.Hour, newTime.Minute));
            }
        }

        private void RaiseDayChanged(DateTime newDate)
        {
            if (this.DayChanged != null)
            {
                this.DayChanged(this, newDate);
            }
        }

        private void SendUpdates()
        {
            DateTime now = this.dateTimeSource.Now;

            if (now.Minute != this.lastSavedMinute)
            {
                this.lastSavedMinute = now.Minute;
                this.RaiseMinuteChanged(now);
            }

            if (now.Day != this.lastSavedDay)
            {
                this.lastSavedDay = now.Day;
                this.RaiseDayChanged(now);
            }
        }
    }
}
