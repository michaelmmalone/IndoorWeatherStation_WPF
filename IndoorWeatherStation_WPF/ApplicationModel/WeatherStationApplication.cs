using System;
using IndoorWeatherStation_WPF.Adapters;

namespace IndoorWeatherStation_WPF.ApplicationModel
{
    internal class WeatherStationApplication
    {
        public void Start(Action<MainPageViewModel> viewModelCreatedCallback)
        {
            WeatherStation weatherStation = new WeatherStation();
            MainPageViewModel viewModel = new MainPageViewModel();

            WeatherStationApplication.SubscribeToWeatherStationEvents(weatherStation, viewModel);
            viewModelCreatedCallback(viewModel);
            weatherStation.Start();
        }

        private static void SubscribeToWeatherStationEvents(
            WeatherStation weatherStation,
            MainPageViewModel viewModel)
        {
            TimeFormatter timeFormatter = new TimeFormatter();
            DateFormatter dateFormatter = new DateFormatter();
            HumidityFormatter humidityFormatter = new HumidityFormatter();

            weatherStation.MinuteChanged += (s, newTime) => viewModel.Time = newTime.Format(timeFormatter);
            weatherStation.DayChanged += (s, newDate) => viewModel.Date = dateFormatter.Format(newDate);
            weatherStation.OutdoorTemperatureChanged += (sender, newTemp) => viewModel.OutdoorTemperature = newTemp.Value; //TODO: should VM take value object?
            weatherStation.OutdoorHumidityChanged += (sender, newHumidity) => viewModel.OutdoorHumidity = humidityFormatter.Format(newHumidity);
            weatherStation.IndoorTemperatureChanged += (sender, newTemp) => viewModel.IndoorTemperature = newTemp.Value;
            weatherStation.IndoorHumidityChanged += (sender, newHumidity) => viewModel.IndoorHumidity = humidityFormatter.Format(newHumidity);
        }
    }
}