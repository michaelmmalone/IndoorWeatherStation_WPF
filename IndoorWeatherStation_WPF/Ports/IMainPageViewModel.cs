
namespace IndoorWeatherStation_WPF.Ports
{
    internal interface IMainPageViewModel
    {
        string Time { get; }
        string Date { get; }
        int OutdoorTemperature { get; }
        string OutdoorHumidity { get; }
    }
}
