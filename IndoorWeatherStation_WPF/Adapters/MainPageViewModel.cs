using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using IndoorWeatherStation_WPF.ApplicationModel;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.Adapters
{
    [DebuggerDisplay("Time={time}, Date={date}")]
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string time;
        private string date;
        private int outdoorTemperature;
        private string outdoorHumidity;
        private int indoorTemperature;
        private string indoorHumidity;

        public MainPageViewModel(IWeatherStation weatherStation)
        {
            TimeFormatter timeFormatter = new TimeFormatter();
            DateFormatter dateFormatter = new DateFormatter();
            HumidityFormatter humidityFormatter = new HumidityFormatter();

            weatherStation.MinuteChanged += (s, newTime) =>
            {
                this.Time = timeFormatter.Format(newTime);
            };

            weatherStation.DayChanged += (s, newDate) =>
            {
                this.Date = dateFormatter.Format(newDate);
            };

            weatherStation.OutdoorTemperatureChanged += (sender, newTemp) =>
            {
                this.OutdoorTemperature = newTemp;
            };

            weatherStation.OutdoorHumidityChanged += (sender, newHumidity) =>
            {
                this.OutdoorHumidity = humidityFormatter.Format(newHumidity);
            };

            weatherStation.IndoorTemperatureChanged += (sender, newTemp) =>
            {
                this.IndoorTemperature = newTemp;
            };

            weatherStation.IndoorHumidityChanged += (sender, newHumidity) =>
            {
                this.IndoorHumidity = humidityFormatter.Format(newHumidity);
            };
        }

        #region IMainPageViewModel

        public string Time
        {
            get { return this.time; }

            set
            {
                if (value == this.time) return;

                this.time = value;
                this.OnPropertyChanged();
            }
        }

        public string Date
        {
            get { return this.date; }

            set
            {
                if (value == this.date) return;

                this.date = value;
                this.OnPropertyChanged();
            }
        }

        public int OutdoorTemperature
        {
            get { return this.outdoorTemperature; }

            set
            {
                if (value == this.outdoorTemperature) return;

                this.outdoorTemperature = value;
                this.OnPropertyChanged();
            }
        }

        public string OutdoorHumidity
        {
            get { return this.outdoorHumidity; }

            set
            {
                if (value == this.outdoorHumidity) return;

                this.outdoorHumidity = value;
                this.OnPropertyChanged();
            }
        }

        public int IndoorTemperature
        {
            get { return this.indoorTemperature; }

            set
            {
                if (value == this.indoorTemperature) return;

                this.indoorTemperature = value;
                this.OnPropertyChanged();
            }
        }

        public string IndoorHumidity
        {
            get { return this.indoorHumidity; }

            set
            {
                if (value == this.indoorHumidity) return;

                this.indoorHumidity = value;
                this.OnPropertyChanged();
            }
        }

        #endregion IMainPageViewModel

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
