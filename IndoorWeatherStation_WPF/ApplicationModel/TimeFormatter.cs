using System;

namespace IndoorWeatherStation_WPF.ApplicationModel
{
    internal class TimeFormatter
    {
        public string Format(DateTime time)
        {
            // Example: "10:45"
            return time.ToString("h:mm");
        }
    }
}
