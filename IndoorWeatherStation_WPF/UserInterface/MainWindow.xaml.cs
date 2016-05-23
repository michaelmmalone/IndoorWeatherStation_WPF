using System.Windows;
using IndoorWeatherStation_WPF.Adapters;
using IndoorWeatherStation_WPF.Ports;
using IndoorWeatherStation_WPF.Simulators;

namespace IndoorWeatherStation_WPF.UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.CleanUp();

            this.weatherStation = new WeatherStation();
            this.viewModel = this.weatherStation.CreateViewModel();
            this.DataContext = this.viewModel;

            this.weatherStation.Start();
        }

        private void CleanUp()
        {
            if (this.weatherStation != null)
            {
                this.weatherStation.Dispose();
                this.weatherStation = null;
            }
        }

        private IMainPageViewModel viewModel;
        private IWeatherStation weatherStation;
    }
}
