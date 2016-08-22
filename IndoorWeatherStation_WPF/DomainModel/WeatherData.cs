using System.Diagnostics;

namespace IndoorWeatherStation_WPF.DomainModel
{
    [DebuggerDisplay("Temperature={Temperature}, Humidity={Humidity}")]
    internal class WeatherData
    {
        public static WeatherData Empty = new WeatherData();

        public WeatherData(Temperature temperature, Humidity humidity)
        {
            this.Temperature = temperature;
            this.Humidity = humidity;
        }

        private WeatherData() { }

        public Temperature Temperature { get; private set; }
        public Humidity Humidity { get; private set; }
    }
}
