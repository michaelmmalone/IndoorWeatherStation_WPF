using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fixtures;
using Tests.Helper;

namespace Tests.Component
{
    [TestClass]
    public class MainPageViewModelTests
    {
        [TestMethod]
        [TestCategory("Component")]
        public void MinuteChanged_SetsTime()
        {
            // Arrange
            MainPageViewModelFixture mainPageViewModelFixture = new MainPageViewModelFixture();
            bool eventRaised = false;
            bool wrongEventRaised = false;

            mainPageViewModelFixture.Target.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Time")
                {
                    eventRaised = true;
                }

                if (args.PropertyName == "Date")
                {
                    wrongEventRaised = true;
                }
            };

            // Act
            mainPageViewModelFixture.SignalMinuteHasChanged();

            // Assert
            eventRaised.Should().BeTrue();
            wrongEventRaised.Should().BeFalse();
            mainPageViewModelFixture.Target.Time.Should().Contain(DateTime.Now.Minute.ToString());
        }

        [TestMethod]
        [TestCategory("Component")]
        public void DayChanged_SetsDate()
        {
            // Arrange
            MainPageViewModelFixture mainPageViewModelFixture = new MainPageViewModelFixture();
            bool eventRaised = false;
            bool wrongEventRaised = false;

            mainPageViewModelFixture.Target.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Date")
                {
                    eventRaised = true;
                }

                if (args.PropertyName == "Time")
                {
                    wrongEventRaised = true;
                }
            };

            // Act
            mainPageViewModelFixture.SignalDayHasChanged();

            // Assert
            eventRaised.Should().BeTrue();
            wrongEventRaised.Should().BeFalse();
            mainPageViewModelFixture.Target.Date.Should().Contain(DateTime.Now.Day.ToString());
        }

        [TestMethod]
        [TestCategory("Component")]
        public void OutdoorTemeratureChanged_SetsOutdoorTemperature()
        {
            // Arrange
            MainPageViewModelFixture mainPageViewModelFixture = 
                new MainPageViewModelFixture(expectedOutdoorTemperature: 55);
            bool eventRaised = false;

            mainPageViewModelFixture.Target.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "OutdoorTemperature")
                {
                    eventRaised = true;
                }
            };

            // Act
            mainPageViewModelFixture.Start();
            Waiter.Until(() => eventRaised);

            // Assert
            eventRaised.Should().BeTrue();
            mainPageViewModelFixture.Target.OutdoorTemperature.Should().Be(55);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void OutdoorHumidityChanged_SetsOutdoorHumidity()
        {
            // Arrange
            MainPageViewModelFixture mainPageViewModelFixture =
                new MainPageViewModelFixture(expectedOutdoorHumidity: 55);
            bool eventRaised = false;

            mainPageViewModelFixture.Target.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "OutdoorHumidity")
                {
                    eventRaised = true;
                }
            };

            // Act
            mainPageViewModelFixture.Start();
            Waiter.Until(() => eventRaised);

            // Assert
            eventRaised.Should().BeTrue();
            mainPageViewModelFixture.Target.OutdoorHumidity.Should().Be("55%");
        }

        [TestMethod]
        [TestCategory("Component")]
        public void IndoorTemeratureChanged_SetsIndoorTemperature()
        {
            // Arrange
            MainPageViewModelFixture mainPageViewModelFixture =
                new MainPageViewModelFixture(expectedIndoorTemperature: 55);
            bool eventRaised = false;

            mainPageViewModelFixture.Target.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "IndoorTemperature")
                {
                    eventRaised = true;
                }
            };

            // Act
            mainPageViewModelFixture.Start();
            Waiter.Until(() => eventRaised);

            // Assert
            eventRaised.Should().BeTrue();
            mainPageViewModelFixture.Target.IndoorTemperature.Should().Be(55);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void IndoorHumidityChanged_SetsIndoorHumidity()
        {
            // Arrange
            MainPageViewModelFixture mainPageViewModelFixture =
                new MainPageViewModelFixture(expectedIndoorHumidity: 55);
            bool eventRaised = false;

            mainPageViewModelFixture.Target.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "IndoorHumidity")
                {
                    eventRaised = true;
                }
            };

            // Act
            mainPageViewModelFixture.Start();
            Waiter.Until(() => eventRaised);

            // Assert
            eventRaised.Should().BeTrue();
            mainPageViewModelFixture.Target.IndoorHumidity.Should().Be("55%");
        }
    }
}
