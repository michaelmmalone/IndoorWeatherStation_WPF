using System;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.Simulators
{
    internal class DateTimeSourceSimulator : IDateTimeSource
    {
        private DateTime lastDateTime = DateTime.Now;

        #region IDateTimeSource

        public DateTime Now
        {
            get
            {
                Random random = new Random();

                this.lastDateTime = this.lastDateTime
                    .AddMinutes(random.Next(0, 2))
                    .AddDays(random.Next(0, 2));
                
                return this.lastDateTime;
            }
        }

        #endregion IDateTimeSource
    }
}