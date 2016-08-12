using System;
using System.Windows;
using IndoorWeatherStation_WPF.ApplicationModel;
using IndoorWeatherStation_WPF.UserInterface;

namespace IndoorWeatherStation_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool firstTime = true;

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (this.firstTime)
            {
                this.firstTime = false;

                WeatherStationApplication weatherStationApplication = new WeatherStationApplication();

                weatherStationApplication.Start(
                    viewModelCreatedCallback: viewModel => ((MainWindow)this.MainWindow).SetViewModel(viewModel));
            }
        }
    }
}
