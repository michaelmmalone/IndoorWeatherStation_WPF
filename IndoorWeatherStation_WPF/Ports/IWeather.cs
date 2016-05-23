using System;
using System.Threading.Tasks;
using IndoorWeatherStation_WPF.DomainModel;

namespace IndoorWeatherStation_WPF.Ports
{
    internal interface IWeather : IDisposable
    {
        Task<WeatherData> GetWeatherAsync();
    }
}