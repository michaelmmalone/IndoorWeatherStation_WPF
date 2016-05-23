using System;
using IndoorWeatherStation_WPF.Adapters;
using Tests.Mocks;

namespace Tests.Fixtures
{
    internal class MainPageViewModelFixture
    {
        private readonly int expectedOutdoorTemperature;
        private readonly int expectedOutdoorHumidity;
        private readonly int expectedIndoorTemperature;
        private readonly int expectedIndoorHumidity;
        private readonly IWeatherStationMock weatherStationMock;

        public MainPageViewModelFixture(
            int expectedOutdoorTemperature = 0,
            int expectedOutdoorHumidity = 0,
            int expectedIndoorTemperature = 0,
            int expectedIndoorHumidity = 0)
        {
            this.expectedOutdoorTemperature = expectedOutdoorTemperature;
            this.expectedOutdoorHumidity = expectedOutdoorHumidity;
            this.expectedIndoorTemperature = expectedIndoorTemperature;
            this.expectedIndoorHumidity = expectedIndoorHumidity;

            this.weatherStationMock = new IWeatherStationMock();
            this.Target = new MainPageViewModel(this.weatherStationMock);
        }

        public MainPageViewModel Target { get; private set; }

        public void Start()
        {
            if (this.expectedOutdoorTemperature != 0)
            {
                this.weatherStationMock.RaiseOutdoorTemperatureChanged(this.expectedOutdoorTemperature);
            }

            if (this.expectedOutdoorHumidity != 0)
            {
                this.weatherStationMock.RaiseOutdoorHumidityChanged(this.expectedOutdoorHumidity);
            }

            if (this.expectedIndoorTemperature != 0)
            {
                this.weatherStationMock.RaiseIndoorTemperatureChanged(this.expectedIndoorTemperature);
            }

            if (this.expectedIndoorHumidity != 0)
            {
                this.weatherStationMock.RaiseIndoorHumidityChanged(this.expectedIndoorHumidity);
            }
        }

        public void SignalDayHasChanged()
        {
            this.weatherStationMock.RaiseDayChanged(DateTime.Now);
        }

        public void SignalMinuteHasChanged()
        {
            this.weatherStationMock.RaiseMinuteChanged(DateTime.Now);
        }
    }
}