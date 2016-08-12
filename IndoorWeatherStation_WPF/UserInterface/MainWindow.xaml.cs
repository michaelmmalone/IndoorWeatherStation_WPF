using System.Windows;
using IndoorWeatherStation_WPF.Adapters;

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
        }

        internal void SetViewModel(MainPageViewModel mainPageViewModel)
        {
            this.viewModel = mainPageViewModel;
            this.DataContext = this.viewModel;
        }

        private MainPageViewModel viewModel;
    }
}
