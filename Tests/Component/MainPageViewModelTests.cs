using System;
using FluentAssertions;
using IndoorWeatherStation_WPF.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Component
{
    [TestClass]
    public class MainPageViewModelTests
    {
        [TestMethod]
        [TestCategory("Component")]
        public void MinuteChanged_RaisesPropertyChangedEvent()
        {
            // Arrange
            MainPageViewModel classUnderTest = new MainPageViewModel();
            bool eventRaised = false;

            classUnderTest.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Time")
                {
                    eventRaised = true;
                }
            };

            // Act
            classUnderTest.Time = new DateTime(2016, 6, 10, 8, 35, 0).ToLongTimeString();

            // Assert
            eventRaised.Should().BeTrue();
            classUnderTest.Time.Should().Be("8:35:00 AM");
        }

        [TestMethod]
        [TestCategory("Component")]
        public void DayChanged_RaisesPropertyChangedEvent()
        {
            // Arrange
            MainPageViewModel classUnderTest = new MainPageViewModel();
            bool eventRaised = false;

            classUnderTest.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Date")
                {
                    eventRaised = true;
                }
            };

            // Act
            classUnderTest.Date = new DateTime(2016, 6, 10, 8, 35, 0).ToLongDateString();

            // Assert
            eventRaised.Should().BeTrue();
            classUnderTest.Date.Should().Be("Friday, June 10, 2016");
        }

        [TestMethod]
        [TestCategory("Component")]
        public void OutdoorTemeratureChanged_RaisesPropertyChangedEvent()
        {
            // Arrange
            MainPageViewModel classUnderTest = new MainPageViewModel();
            bool eventRaised = false;

            classUnderTest.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "OutdoorTemperature")
                {
                    eventRaised = true;
                }
            };

            // Act
            classUnderTest.OutdoorTemperature = 45;

            // Assert
            eventRaised.Should().BeTrue();
            classUnderTest.OutdoorTemperature.Should().Be(45);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void OutdoorHumidityChanged_RaisesPropertyChangedEvent()
        {
            // Arrange
            MainPageViewModel classUnderTest = new MainPageViewModel();
            bool eventRaised = false;

            classUnderTest.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "OutdoorHumidity")
                {
                    eventRaised = true;
                }
            };

            // Act
            classUnderTest.OutdoorHumidity = "55%";

            // Assert
            eventRaised.Should().BeTrue();
            classUnderTest.OutdoorHumidity.Should().Be("55%");
        }

        [TestMethod]
        [TestCategory("Component")]
        public void IndoorTemeratureChanged_RaisesPropertyChangedEvent()
        {
            // Arrange
            MainPageViewModel classUnderTest = new MainPageViewModel();
            bool eventRaised = false;

            classUnderTest.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "IndoorTemperature")
                {
                    eventRaised = true;
                }
            };

            // Act
            classUnderTest.IndoorTemperature = 55;

            // Assert
            eventRaised.Should().BeTrue();
            classUnderTest.IndoorTemperature.Should().Be(55);
        }

        [TestMethod]
        [TestCategory("Component")]
        public void IndoorHumidityChanged_RaisesPropertyChangedEvent()
        {
            // Arrange
            MainPageViewModel classUnderTest = new MainPageViewModel();
            bool eventRaised = false;

            classUnderTest.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "IndoorHumidity")
                {
                    eventRaised = true;
                }
            };

            // Act
            classUnderTest.IndoorHumidity = "55%";

            // Assert
            eventRaised.Should().BeTrue();
            classUnderTest.IndoorHumidity.Should().Be("55%");
        }
    }
}
