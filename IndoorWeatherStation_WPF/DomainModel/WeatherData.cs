using System.Diagnostics;

namespace IndoorWeatherStation_WPF.DomainModel
{
    [DebuggerDisplay("Temperature={Temperature}, Humidity={Humidity}")]
    internal class WeatherData
    {
        public static WeatherData Empty = new WeatherData(0, 0);

        public WeatherData(int temperature, int humidity)
        {
            this.Temperature = temperature;
            this.Humidity = humidity;
        }

        public int Temperature { get; private set; }
        public int Humidity { get; private set; }
    }
}
