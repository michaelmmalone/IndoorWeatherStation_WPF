using System;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.Adapters
{
    internal class DateTimeSource : IDateTimeSource
    {
        public DateTimeSource()
        {
            this.Now = DateTime.Now;
        }

        public DateTime Now { get; private set; }
    }
}