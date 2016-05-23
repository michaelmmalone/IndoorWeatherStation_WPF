using System;

namespace IndoorWeatherStation_WPF.ApplicationModel
{
    internal class DateFormatter
    {
        public string Format(DateTime time)
        {
            // Example: "Monday  12/14/2015"
            return time.ToString("dddd  M/d/yyyy");
        }
    }
}
