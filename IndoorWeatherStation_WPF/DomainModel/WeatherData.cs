using System.Diagnostics;

namespace IndoorWeatherStation_WPF.DomainModel
{
    [DebuggerDisplay("Temperature={Temperature}, Humidity={Humidity}")]
    internal class WeatherData
    {
        public static WeatherData Empty = new WeatherData();

        public WeatherData(Temperature temperature, Humidity humidity)
        {
            this.Temperature_New = temperature;
            this.Humidity_New = humidity;

            //TODO: temporary
            this.Temperature = this.Temperature_New.Value;
            this.Humidity = this.Humidity_New.Value;
        }

        private WeatherData() { }

        public int Temperature { get; private set; }
        public int Humidity { get; private set; }

        public Temperature Temperature_New { get; private set; }
        public Humidity Humidity_New { get; private set; }
    }
}
