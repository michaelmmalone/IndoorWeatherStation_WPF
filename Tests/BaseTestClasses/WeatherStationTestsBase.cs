using FluentAssertions;
using IndoorWeatherStation_WPF.Ports;
using Tests.Helper;

namespace Tests.BaseTestClasses
{
    public abstract class WeatherStationTestsBase
    {
        public virtual void MinuteChanged_RaisedWhenStartIsCalled()
        {
            // Arrange
            using (IWeatherStation target = this.GetWeatherStation())
            {
                bool eventCalled = false;

                target.MinuteChanged += (s, e) => eventCalled = true;

                // Act
                target.Start();

                // Assert
                eventCalled.Should().BeTrue();
            }
        }

        public virtual void DayChanged_RaisedWhenStartIsCalled()
        {
            // Arrange
            using (IWeatherStation target = this.GetWeatherStation())
            {
                bool eventCalled = false;

                target.DayChanged += (s, e) => eventCalled = true;

                // Act
                target.Start();

                // Assert
                eventCalled.Should().BeTrue();
            }
        }

        public virtual void OutdoorTemperatureyChanged_RaisedWhenStartIsCalled()
        {
            // Arrange
            using (IWeatherStation target = this.GetWeatherStation())
            {
                bool eventCalled = false;

                target.OutdoorTemperatureChanged += (s, e) => eventCalled = true;

                // Act
                target.Start();
                Waiter.Until(() => eventCalled);

                // Assert
                eventCalled.Should().BeTrue();
            }
        }

        public virtual void OutdoorHumidityChanged_RaisedWhenStartIsCalled()
        {
            // Arrange
            using (IWeatherStation target = this.GetWeatherStation())
            {
                bool eventCalled = false;

                target.OutdoorHumidityChanged += (s, e) => eventCalled = true;

                // Act
                target.Start();
                Waiter.Until(() => eventCalled);

                // Assert
                eventCalled.Should().BeTrue();
            }
        }

        public virtual void IndoorTemperatureyChanged_RaisedWhenStartIsCalled()
        {
            // Arrange
            using (IWeatherStation target = this.GetWeatherStation())
            {
                bool eventCalled = false;

                target.IndoorTemperatureChanged += (s, e) => eventCalled = true;

                // Act
                target.Start();
                Waiter.Until(() => eventCalled);

                // Assert
                eventCalled.Should().BeTrue();
            }
        }

        public virtual void IndoorHumidityChanged_RaisedWhenStartIsCalled()
        {
            // Arrange
            using (IWeatherStation target = this.GetWeatherStation())
            {
                bool eventCalled = false;

                target.IndoorHumidityChanged += (s, e) => eventCalled = true;

                // Act
                target.Start();
                Waiter.Until(() => eventCalled);

                // Assert
                eventCalled.Should().BeTrue();
            }
        }

        internal abstract IWeatherStation GetWeatherStation();
    }
}
