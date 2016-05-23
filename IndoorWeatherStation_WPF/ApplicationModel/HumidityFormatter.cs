
namespace IndoorWeatherStation_WPF.ApplicationModel
{
    internal class HumidityFormatter
    {
        public string Format(int humidity)
        {
            // Example: "64%"
            return string.Format("{0}%", humidity);
        }
    }
}
